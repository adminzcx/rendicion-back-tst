using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.ExpenseFormAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate
{
    public class Expense : BaseEntity
    {
        public virtual User User { get; set; }

        public virtual Reason Reason { get; set; }

        public virtual Concept Concept { get; set; }

        public DateTime ExpenseDate { get; set; }

        public DateTime PresentationDate { get; set; }

        public decimal? Amount { get; set; }

        public string Description { get; set; }

        public string DocumentAttached { get; set; }

        public string GoogleURL { get; set; }

        public virtual Segment Segment { get; set; }

        public virtual Source Source { get; set; }

        public string ImageMAP { get; set; }

        public virtual TechnicalVisit TechnicalVisit { get; set; }

        public decimal? MobilityAmount { get; set; }

        public string VisitResult { get; set; }

        public string Term { get; set; }

        public decimal? KM { get; set; }

        public decimal? PriceByKM { get; set; }

        public decimal? TotalAmount { get; set; }

        public double? SourceLatitude { get; set; }

        public double? SourceLongitude { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string Address { get; set; }

        public string DNI { get; set; }

        public string RequestNumber { get; set; }

        public string Device { get; set; }

        public virtual ExpenseStatus Status { get; set; }

        public virtual ExpenseForm ExpenseForm { get; set; }

        public virtual Campaign Campaign { get; set; }

        public virtual RejectReason RejectReason { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool? RevertEnabled { get; set; } = false;

        private List<ExpenseUser> _expenseUsers = new List<ExpenseUser>();

        public virtual IReadOnlyList<ExpenseUser> ExpenseUsers => _expenseUsers.Where(x => x.IsDeleted != true).ToList();

        private List<ExpenseAdvice> _advices = new List<ExpenseAdvice>();

        public virtual IReadOnlyList<ExpenseAdvice> Advices => _advices.ToList();



        #region Advices

        public void GenerateAdvices(IEnumerable<ExpenseStops> validationToExecute, IEnumerable<Expense> expenseToValidate)
        {


            #region Advice_1

            if (ValidateDate(validationToExecute))
            {
                _advices.Add(new ExpenseAdvice("Fecha incorrecta.", "La fecha de presentación del gasto está por fuera del tope permitido."));
            }

            #endregion

            #region Advice_2
            if (ValidateAmount(validationToExecute))
            {
                _advices.Add(new ExpenseAdvice("Monto incorrecto.", "El monto del gasto excede el permitido."));

            }
            #endregion

            #region Advice_3
            if (ValidateAmountPerMonth(validationToExecute, expenseToValidate))
            {
                _advices.Add(new ExpenseAdvice("Monto incorrecto.", "El monto del gasto excede el tope permitido por mes."));
            }
            #endregion

            #region Advice_4
            if (ValidateTotalPerMonth(validationToExecute, expenseToValidate))
            {
                _advices.Add(new ExpenseAdvice("Tope superado.", "Se superó el tope de cantidad permitido por mes para este tipo de gastos."));
            }
            #endregion

            #region Advice_5
            if (ValidateTravelWithParquingLot(expenseToValidate))
            {
                _advices.Add(new ExpenseAdvice("Gasto incompatible.", "Peaje o estacionamiento sin viaje asociado."));
            }
            #endregion

            #region Advice_6
            if (ValidateTravelWithoutSource(expenseToValidate))
            {
                _advices.Add(new ExpenseAdvice("Viaje mal formado.", "Ruta sin inicio de viaje en sucursal."));
            }
            #endregion
        }

        private bool ValidateDate(IEnumerable<ExpenseStops> validationToExecute)
        {
            var expenseStopToApply = validationToExecute.Where(x => x.TypeStop == (int)StopsEnum.TopesDeFechaLimite).ToList();
            if (!expenseStopToApply.Any()) return false;
            if (DateTime.Today < expenseStopToApply.First().ValidityStartDate) return false;

            var month = (int)(expenseStopToApply.First().CapAmount * -1);
            var date = DateTime.Today;

            if (ExpenseForm?.PresentationDate != null)
            {
                date = ExpenseForm.PresentationDate;
            }

            return ExpenseDate < date.AddMonths(month);
        }

        private bool ValidateAmount(IEnumerable<ExpenseStops> validationToExecute)
        {
            var expenseStopToApply = validationToExecute.Where(x => x.TypeStop == (int)StopsEnum.TopesDeMontoARendir).ToList();
            if (!expenseStopToApply.Any()) return false;

            return (Amount + MobilityAmount) > expenseStopToApply.First().CapAmount;
        }

        private bool ValidateAmountPerMonth(IEnumerable<ExpenseStops> validationToExecute, IEnumerable<Expense> expenseToValidate)
        {
            var expenseStopToApply = validationToExecute.Where(x => x.TypeStop == (int)StopsEnum.TopesDeMontoPorMes).ToList();
            if (!expenseStopToApply.Any()) return false;

            var expenseList = expenseToValidate.Where(x => x.Concept.Id == Concept.Id && x.ExpenseDate.Month == ExpenseDate.Month).ToList();
            return ((Amount + MobilityAmount) + expenseList.Sum((x => x.Amount)) > expenseStopToApply.First().CapAmount);
        }

        private bool ValidateTotalPerMonth(IEnumerable<ExpenseStops> validationToExecute, IEnumerable<Expense> expenseToValidate)
        {
            var expenseStopToApply = validationToExecute.Where(x => x.TypeStop == (int)StopsEnum.TopesDeCantidadPorMes).ToList();
            if (!expenseStopToApply.Any()) return false;

            var expenseList = expenseToValidate.Where(x => x.Concept.Id == Concept.Id).ToList();
            return ((expenseList.Count() + 1) > expenseStopToApply.First().CapAmount);
        }

        private bool ValidateTravelWithParquingLot(IEnumerable<Expense> expenseToValidate)
        {

            if (!Concept.IsExpenseParquingLot && !Concept.IsExpenseToll) return false;

            var expenseToApply = expenseToValidate.Where(x => x.ExpenseDate == ExpenseDate).ToList();
            if (!expenseToApply.Any()) return false;

            return (!expenseToApply.Where((x => x.Concept.IsCarOrMotociclye)).Any());
        }

        private bool ValidateTravelWithoutSource(IEnumerable<Expense> expenseToValidate)
        {

            if (!Concept.IsCarOrMotociclye) return false;

            var expenseToApply = expenseToValidate.Where(x => x.ExpenseDate == ExpenseDate && x.Concept.IsCarOrMotociclye && x.Source.Id == (int)SourceEnum.Sucursal).ToList();
            if (expenseToApply.Any()) return false;

            return (Source.Id != (int)SourceEnum.Sucursal);
        }
        #endregion


        #region Users
        public virtual void AddUsers(List<ExpenseUser> usersToAdd)
        {
            if (usersToAdd == null) return;
            _expenseUsers.AddRange(usersToAdd);
        }


        #endregion


        #region GetPrices

        public decimal GetPriceByKm(List<KmPriceConfiguration> kmConfigurations, DateTime currentDate)
        {
            if (kmConfigurations == null) return 0;

            //ByUser
            var configuration = kmConfigurations.Find(x => x.User != null && (x.User.Id == User.Id && x.StartDate <= currentDate));
            if (configuration != null) return configuration.Price;

            //ByZone & subZone
            configuration = kmConfigurations.Find(x => x.SubZone != null && User.SubZone != null && (x.Zone.Id == User.Zone.Id && x.SubZone.Id == User.SubZone.Id && x.StartDate <= currentDate));
            if (configuration != null) return configuration.Price;

            //ByZone 
            configuration = kmConfigurations.Find(x => x.Zone != null && (x.Zone.Id == User.Zone.Id && x.StartDate <= currentDate));
            if (configuration != null) return configuration.Price;

            //Base price
            configuration = kmConfigurations.Find(x => x.Zone == null && x.User == null && x.StartDate <= currentDate);
            return configuration?.Price ?? 0;
        }

        #endregion


        #region Authorization

        public ExpenseStatusEnum GetApprovalStatusLevel(ExpenseStatusEnum currentStatus, ExpenseFormStatusEnum expenseFormStatusEnum)
        {
            RevertEnabled = true;
            switch (expenseFormStatusEnum)
            {
                case ExpenseFormStatusEnum.Presentada:
                    return ExpenseStatusEnum.Autorizado;

                case ExpenseFormStatusEnum.Autorizado:
                    return ExpenseStatusEnum.Revisado;

                case ExpenseFormStatusEnum.Revisado:
                    return ExpenseStatusEnum.Aprobado;

                default:
                    return ExpenseStatusEnum.Presentado;
            }
        }

        public ExpenseStatusEnum GetRejectStatusLevel(ExpenseStatusEnum currentStatus, ExpenseFormStatusEnum expenseFormStatusEnum)
        {
            RevertEnabled = false;
            switch (currentStatus)
            {
                case ExpenseStatusEnum.Autorizado:
                    return ExpenseStatusEnum.Presentado;

                case ExpenseStatusEnum.Revisado:
                    return ExpenseStatusEnum.Autorizado;

                case ExpenseStatusEnum.Aprobado:
                    return ExpenseStatusEnum.Revisado;

                case ExpenseStatusEnum.Rechazado:

                    switch (expenseFormStatusEnum)
                    {
                        case ExpenseFormStatusEnum.Aprobado:
                            return ExpenseStatusEnum.Revisado;

                        case ExpenseFormStatusEnum.Revisado:
                            return ExpenseStatusEnum.Autorizado;

                        case ExpenseFormStatusEnum.Autorizado:
                            return ExpenseStatusEnum.Presentado;

                        default:
                            return ExpenseStatusEnum.Presentado;
                    }

                default:
                    return ExpenseStatusEnum.Presentado;
            }
        }

        #endregion



    }
}
