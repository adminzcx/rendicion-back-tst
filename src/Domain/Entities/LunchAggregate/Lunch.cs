using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.LunchFormAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prome.Viaticos.Server.Domain.Entities.LunchAggregate
{
    public class Lunch : BaseEntity
    {
        public Lunch()
            : base() { }

        public string Collaborator { get; set; }

        public string EmployeeRecord { get; set; }

        public DateTime LunchDate { get; set; }

        public decimal Amount { get; set; }

        public string Device { get; set; }

        public virtual User User { get; set; }

        public virtual User CreatedUser { get; set; }

        public virtual LunchForm LunchForm { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool IsInternalCollaborator { get; set; }

        private List<LunchAdvice> _advices = new List<LunchAdvice>();

        public virtual IReadOnlyList<LunchAdvice> Advices => _advices.ToList();

        public void GenerateAdvices(IEnumerable<UserAbsenteeism> absenteeismToValidate)
        {


            #region Advice_1

            if (absenteeismToValidate != null && IfExistAbsenteeism(absenteeismToValidate))
            {
                _advices.Add(new LunchAdvice("Almuerzo incompatible.", "Almuerzo incompatible con ausencia."));
            }

            #endregion

            #region Advice_2

            if (absenteeismToValidate != null && IfExistExternalLunch(absenteeismToValidate))
            {
                _advices.Add(new LunchAdvice("Almuerzo duplicado.", "Ya existe otro almuerzo registrado para el usuario en la fecha del gasto."));
            }

            #endregion
        }

        private bool IfExistAbsenteeism(IEnumerable<UserAbsenteeism> absenteeismToValidate)
        {
            var result = absenteeismToValidate.Count(x => x.Source == nameof(FileImportationEnum.Calipso));

            return (result > 0);
        }
        private bool IfExistExternalLunch(IEnumerable<UserAbsenteeism> absenteeismToValidate)
        {
            var result = absenteeismToValidate.Count(x => x.Source == nameof(FileImportationEnum.Edenred));

            return (result > 0);
        }
    }
}
