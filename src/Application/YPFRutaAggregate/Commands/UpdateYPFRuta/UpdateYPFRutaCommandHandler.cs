using Prome.Viaticos.Server.Application._Common.Handlers;
using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;

namespace Prome.Viaticos.Server.Application.YPFRutaAggregate.Commands.UpdateYPFRuta
{
    public class UpdateYPFRutaCommandHandler : CommandHandler<UpdateYPFRutaCommand>
    {
        private readonly IDateTime _dateTimeService;

        public UpdateYPFRutaCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper,
            IDateTime dateTimeService)
            : base(unitOfWork, mapper)
        {
            _dateTimeService = dateTimeService;
        }

        public override async Task<Unit> Handle(UpdateYPFRutaCommand request, CancellationToken cancellationToken)
        {
            var entity = await FindById<Domain.Entities.YPFRutaAggregate.Datos_YPF>(request.Id);

            entity.Fecha = request.Fecha;
            entity.Contrato = request.Contrato;
            entity.Subcuenta = request.Subcuenta;
            entity.Centro_Costo = request.Centro_Costo;
            entity.Establecimiento = request.Establecimiento;
            entity.Domicilio = request.Domicilio;
            entity.Localidad = request.Localidad;
            entity.Provincia = request.Provincia;
            entity.Tarjeta = request.Tarjeta;
            entity.Conductor = request.Conductor;
            entity.Tipo_Identificacion_Conductor = request.Tipo_Identificacion_Conductor;
            entity.Nro_Identificacion_Conductor = request.Nro_Identificacion_Conductor;
            entity.Tipo_Identificacion_Tarjeta = request.Tipo_Identificacion_Tarjeta;
            entity.Identificacion_Tarjeta = request.Identificacion_Tarjeta;
            entity.Odometro = request.Odometro;
            entity.Remito = request.Remito;
            entity.Producto = request.Producto;
            entity.Litros_Unidades = request.Litros_Unidades;
            entity.Precio_PVP_Establecimiento = request.Precio_PVP_Establecimiento;
            entity.Imp_Total_PVP_Establecimiento = request.Imp_Total_PVP_Establecimiento;
            entity.Precio_YER = request.Precio_YER;
            entity.Imp_Total_YER = request.Imp_Total_YER;
            entity.Divisa = request.Divisa;
            entity.Factura = request.Factura;
            entity.IVA = request.IVA;
            entity.Imp_CO2 = request.Imp_CO2;
            entity.Tasa_Vial = request.Tasa_Vial;
            entity.Imp_Comb_Liq = request.Imp_Comb_Liq;
            entity.Extracto = request.Extracto;

        _unitOfWork.Repository<Domain.Entities.YPFRutaAggregate.Datos_YPF>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
