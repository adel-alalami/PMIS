using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IDeliverableRepository
    {
        public List<Deliverable> GetDeliverables(int projectPhaseId);
        public Deliverable GetById(int DeliverableId);
        public void InsertDeliverable(Deliverable deliverable);
        public void RemoveDeliverable(int deliverableId);
        public void UpdateDeliverable(Deliverable deliverable);
    }
}
