using System;
using System.Data.Entity;

namespace CommandQuery.Sample.Models
{
    public abstract class TrackUpdate
    {
        public TrackUpdate()
        {
            CreatedDate = DateTime.UtcNow;
            CreatedBy = "Anonymous";
            UpdatedDate = DateTime.UtcNow;
            UpdatedBy = "Anonymous";
        }

        public DateTime CreatedDate { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime UpdatedDate { get; private set; }
        public string UpdatedBy { get; private set; }

        public void UpdateTrackingInfo(EntityState state, string userName)
        {
            if (state == EntityState.Added)
            {
                CreatedDate = DateTime.UtcNow;
                CreatedBy = userName;
            }

            UpdatedDate = DateTime.UtcNow;
            UpdatedBy = userName;
        }
    }
}