using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Prome.Viaticos.Server.Domain.Entities.UserAggregate
{
    public class Position : BaseNameCodeEntity
    {
        public Position(string code, string name)
            : base(code, name) { }

        public bool IsBranchRequired =>
                Code == nameof(PositionTypeEnum.EC)
            || Code == nameof(PositionTypeEnum.ECS);

        public bool IsSubZoneRequired => Code == nameof(PositionTypeEnum.JZ);

        public bool IsZoneRequired => Code == nameof(PositionTypeEnum.SGZ);

        public bool IsSectorRequired =>
                Code == nameof(PositionTypeEnum.ACM)
            || Code == nameof(PositionTypeEnum.JCM);

        public bool IsManagementRequired => Code == nameof(PositionTypeEnum.GCM);

        public PositionTypeEnum GetNextPosition()
        {
            if (string.IsNullOrWhiteSpace(Code)) return PositionTypeEnum.JZ;

            if (Code == nameof(PositionTypeEnum.EC)) return PositionTypeEnum.JZ;

            if (Code == nameof(PositionTypeEnum.ECS)) return PositionTypeEnum.JZ;

            if (Code == nameof(PositionTypeEnum.JZ)) return PositionTypeEnum.SGZ;

            if (Code == nameof(PositionTypeEnum.ACM)) return PositionTypeEnum.JCM;

            if (Code == nameof(PositionTypeEnum.JCM)) return PositionTypeEnum.GCM;

            if (Code == nameof(PositionTypeEnum.GCM)) return PositionTypeEnum.GCM;

            else return PositionTypeEnum.JZ;
        }

        public ICollection<PositionTypeEnum> GetParesLevePosition()
        {
            return string.IsNullOrWhiteSpace(Code)
                                ? null
                                : new Collection<PositionTypeEnum> { PositionTypeEnum.GCM, PositionTypeEnum.ALL };
        }

        public ICollection<PositionTypeEnum> GetFirstLevelPosition()
        {
            if (string.IsNullOrWhiteSpace(Code)) return null;

            var result = new Collection<PositionTypeEnum>();

            switch (this.Code)
            {
                case "JZ":
                    result.Add(PositionTypeEnum.EC);
                    result.Add(PositionTypeEnum.ECS);
                    break;

                case "SGZ":
                    result.Add(PositionTypeEnum.JZ);
                    break;

                case "GCM":
                    result.Add(PositionTypeEnum.SGZ);
                    result.Add(PositionTypeEnum.JCM);
                    break;

                case "JCM":
                    result.Add(PositionTypeEnum.ACM);
                    break;

                case "ALL":
                    result.Add(PositionTypeEnum.EC);
                    result.Add(PositionTypeEnum.ECS);
                    result.Add(PositionTypeEnum.ALL);
                    break;
            }

            return result;
        }
        public ICollection<PositionTypeEnum> GetIndirectPosition()
        {
            if (string.IsNullOrWhiteSpace(Code)) return null;

            var result = new Collection<PositionTypeEnum>();

            switch (this.Code)
            {
                case "SGZ":
                    result.Add(PositionTypeEnum.EC);
                    result.Add(PositionTypeEnum.ECS);
                    break;

                case "GCM":
                    result.Add(PositionTypeEnum.EC);
                    result.Add(PositionTypeEnum.ECS);
                    result.Add(PositionTypeEnum.JZ);
                    result.Add(PositionTypeEnum.ACM);
                    break;

                case "ALL":
                    result.Add(PositionTypeEnum.EC);
                    result.Add(PositionTypeEnum.ECS);
                    result.Add(PositionTypeEnum.JZ);
                    result.Add(PositionTypeEnum.ACM);
                    result.Add(PositionTypeEnum.ALL);
                    break;

                default:
                    break;
            }

            return result;
        }
    }
}
