using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.TenantManagement.Localization;

namespace Volo.Abp.TenantManagement
{
    public class Edition : FullAuditedAggregateRoot<Guid>
    {
        public virtual string DisplayName { get; protected set; }

        protected Edition()
        {
        }
        protected internal Edition(Guid id, [NotNull] string diaplayName)
        {
            Id = id;
            SetDisplayName(diaplayName);
        }
        protected internal virtual void SetDisplayName([NotNull] string diaplayName)
        {
            DisplayName = Check.NotNullOrWhiteSpace(diaplayName, nameof(diaplayName), EditionConsts.MaxNameLength);
        }
    }

}