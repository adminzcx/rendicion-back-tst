using AutoMapper;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Application.YPFRutaAggregate.Specifications;
using Prome.Viaticos.Server.Domain.Entities.CuentaCorrienteAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Entities.YPFRutaAggregate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.YPFRutaAggregate.Commands.UpdateDataYPF
{
    public class UpdateDataYPFCommandHandler : CommandHandler<UpdateDataYPFCommand>
    {
        public UpdateDataYPFCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper,
            IDateTime dateTimeService)
            : base(unitOfWork, mapper)
        {

        }

        public override async Task<Unit> Handle(UpdateDataYPFCommand request, CancellationToken cancellationToken)
        {
            if (request.FileNameBase64 != "")
            {
                Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
                string base64File = regex.Replace(request.FileResultBase64, string.Empty);
                var base64EncodedBytes = System.Convert.FromBase64String(base64File);

                using (MemoryStream ms = new MemoryStream(base64EncodedBytes))
                {
                    var doc = SpreadsheetDocument.Open(ms, false);

                    WorkbookPart workbookPart = doc.WorkbookPart;
                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                    SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                    foreach (Row r in sheetData.Elements<Row>())
                    {
                        if (r.RowIndex > 1)
                        {
                            CuentasCorrientes ctaCte = new CuentasCorrientes();

                            User user = await _unitOfWork
                                .Repository<User>()
                                .SingleOrDefaultAsync(new ByEmployeeTarjetaYPFSpecification(r.ChildElements[8].InnerText));

                            if (user != null) 
                            {
                                ctaCte.Fecha = Convert.ToDateTime(r.ChildElements[0].InnerText);
                                ctaCte.Legajo = Convert.ToInt32(user.EmployeeRecord);
                                ctaCte.Monto = Convert.ToDecimal(r.ChildElements[17].InnerText);
                                ctaCte.Observaciones = "Dato obtenido desde el Excel de YPF.";

                                await _unitOfWork.Repository<CuentasCorrientes>().AddAsync(ctaCte);
                                await _unitOfWork.CommitAsync();
                            }
                            else
                            {
                                Datos_YPF duplicateYPF = await _unitOfWork
                                    .Repository<Datos_YPF>()
                                    .FirstOrDefaultAsync(new ByDuplicateDataYPF(r.ChildElements[8].InnerText, Convert.ToDateTime(r.ChildElements[0].InnerText), Convert.ToDecimal(r.ChildElements[17].InnerText)));

                                if (duplicateYPF == null)
                                {
                                    Datos_YPF dataYPF = new Datos_YPF()
                                    {
                                        Fecha = Convert.ToDateTime(r.ChildElements[0].InnerText),
                                        Contrato = r.ChildElements[1].InnerText,
                                        Subcuenta = r.ChildElements[2].InnerText,
                                        Centro_Costo = r.ChildElements[3].InnerText,
                                        Establecimiento = r.ChildElements[4].InnerText,
                                        Domicilio = r.ChildElements[5].InnerText,
                                        Localidad = r.ChildElements[6].InnerText,
                                        Provincia = r.ChildElements[7].InnerText,
                                        Tarjeta = r.ChildElements[8].InnerText,
                                        Conductor = r.ChildElements[9].InnerText,
                                        Tipo_Identificacion_Conductor = r.ChildElements[10].InnerText,
                                        Nro_Identificacion_Conductor = r.ChildElements[11].InnerText,
                                        Tipo_Identificacion_Tarjeta = r.ChildElements[12].InnerText,
                                        Identificacion_Tarjeta = r.ChildElements[13].InnerText,
                                        Odometro = r.ChildElements[14].InnerText,
                                        Remito = r.ChildElements[15].InnerText,
                                        Producto = r.ChildElements[16].InnerText,
                                        Litros_Unidades = Convert.ToDecimal(r.ChildElements[17].InnerText),
                                        Precio_PVP_Establecimiento = Convert.ToDecimal(r.ChildElements[18].InnerText),
                                        Imp_Total_PVP_Establecimiento = Convert.ToDecimal(r.ChildElements[19].InnerText),
                                        Precio_YER = Convert.ToDecimal(r.ChildElements[20].InnerText),
                                        Imp_Total_YER = Convert.ToDecimal(r.ChildElements[21].InnerText),
                                        Divisa = r.ChildElements[22].InnerText,
                                        Factura = r.ChildElements[23].InnerText,
                                        IVA = Convert.ToDecimal(r.ChildElements[24].InnerText),
                                        Imp_CO2 = Convert.ToDecimal(r.ChildElements[25].InnerText),
                                        Tasa_Vial = Convert.ToDecimal(r.ChildElements[26].InnerText),
                                        Imp_Comb_Liq = Convert.ToDecimal(r.ChildElements[27].InnerText),
                                        Extracto = r.ChildElements[28].InnerText,
                                        Procesado = false
                                    };

                                    await _unitOfWork.Repository<Datos_YPF>().AddAsync(dataYPF);
                                    await _unitOfWork.CommitAsync();
                                }
                            }
                        }
                    }
                }
            }

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
