using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Domain.Entities.UserAggregate
{
    public class User : DisableableAuditableEntity
    {
        protected User()
        {

        }

        public User(
           string firstName,
           string lastName,
           string email,
           string employeeRecord,
           bool isAdministrator,
           Branch branchFrom,
           Position position,
           string cuit)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            EmployeeRecord = employeeRecord;
            IsAdministrator = isAdministrator;
            BranchFrom = branchFrom;
            Position = position;
            Cuit = cuit;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Cuit { get; set; }

        public string EmployeeRecord { get; private set; }

        public bool IsAdministrator { get; set; }

        public virtual Branch BranchFrom { get; set; }

        public virtual Position Position { get; set; }

        public virtual Category Category { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual Zone Zone { get; set; }

        public virtual SubZone SubZone { get; set; }

        public virtual Sector Sector { get; set; }

        public virtual Management Management { get; set; }

        public PositionTypeEnum NextLevelAdmin => this.Position.GetNextPosition();

        public ICollection<PositionTypeEnum> FirstLevelPosition => this.Position.GetFirstLevelPosition();

        public ICollection<PositionTypeEnum> IndirectsPosition => this.Position.GetIndirectPosition();

        public ICollection<PositionTypeEnum> ParesLevelPosition => this.Position.GetParesLevePosition();

        public string Name => this.FirstName + " " + this.LastName;

        public void Clean()
        {
            Branch = null;
            Zone = null;
            SubZone = null;
            Sector = null;
            Management = null;
            Category = null;
        }

        public ICollection<string> GetRoles()
        {
            var result = new List<string>();

            if (this.Position == null) return result;

            switch (this.Position.Code)
            {
                case "EC":
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.rinde_viaticos));
                    break;

                case "ECS":
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.rinde_viaticos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.rinde_almuerzos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.rinde_caja_chica));

                    break;

                case "JZ":
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.rinde_viaticos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.autoriza_viaticos));
                    break;

                case "SGZ":
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.rinde_viaticos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.autoriza_viaticos));
                    break;

                case "ACM":
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.rinde_viaticos));

                    if (this.Management.HasSpecialPermissions && this.Sector.HasSpecialPermissions)
                    {
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.administra_viaticos));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.revisa_viaticos));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.exporta_viaticos));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.administra_almuerzos));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.revisa_almuerzos));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.importa_almuerzos));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.administra_caja_chica));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.revisa_caja_chica));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.exporta_caja_chica));

                    }
                    break;

                case "JCM":
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.rinde_viaticos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.autoriza_viaticos));

                    if (this.Management.HasSpecialPermissions && this.Sector.HasSpecialPermissions)
                    {
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.administra_viaticos));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.revisa_viaticos));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.exporta_viaticos));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.administra_almuerzos));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.revisa_almuerzos));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.importa_almuerzos));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.revisa_caja_chica));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.administra_caja_chica));
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.exporta_caja_chica));
                    }
                    break;

                case "GCM":
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.rinde_viaticos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.autoriza_viaticos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.pares_autoriza_viaticos));

                    if (this.Management.HasSpecialPermissions)
                    {
                        result.Add(Enum.GetName(typeof(RolEnum), RolEnum.aprueba_viaticos));
                    }
                    break;

                case "ALL":
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.rinde_viaticos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.autoriza_viaticos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.revisa_viaticos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.administra_viaticos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.exporta_viaticos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.pares_autoriza_viaticos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.rinde_almuerzos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.revisa_almuerzos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.administra_almuerzos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.importa_almuerzos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.aprueba_viaticos));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.rinde_caja_chica));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.exporta_caja_chica));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.administra_caja_chica));
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.revisa_caja_chica));
                    break;

                default:
                    result.Add(Enum.GetName(typeof(RolEnum), RolEnum.rinde_viaticos));
                    break;
            }

            return result;
        }

    }

}
