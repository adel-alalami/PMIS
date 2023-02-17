using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class DeliverableRepository : IDeliverableRepository
    {
        private readonly ApplicationDbContext dbContext;
        public DeliverableRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Deliverable GetById(int DeliverableId)
        {
            return dbContext.Deliverables.Include(x => x.ProjectPhase).ThenInclude(x => x.Project).ToList().SingleOrDefault(x => x.DeliverableId == DeliverableId);
        }

        public List<Deliverable> GetDeliverables(int projectPhaseId)
        {
            return dbContext.Deliverables.Where(x => x.ProjectPhaseId == projectPhaseId).Include(x => x.ProjectPhase).ToList();
        }

        public void InsertDeliverable(Deliverable deliverable)
        {
            dbContext.Deliverables.Add(deliverable);
            dbContext.SaveChanges();
        }

        public void RemoveDeliverable(int deliverableId)
        {
            var Deliverable = GetById(deliverableId);
            dbContext.Deliverables.Remove(Deliverable);
            dbContext.SaveChanges();
        }

        public void UpdateDeliverable(Deliverable deliverable)
        {
            var currenrDeliverable = GetById(deliverable.DeliverableId);
            currenrDeliverable.DeliverableName = deliverable.DeliverableName;
            currenrDeliverable.DeliverableDescription = deliverable.DeliverableDescription;
            currenrDeliverable.StartDate = deliverable.StartDate;
            currenrDeliverable.EndDate = deliverable.EndDate;
            dbContext.SaveChanges();
        }
    }
}
