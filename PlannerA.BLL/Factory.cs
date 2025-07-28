using PlannerA.Model;

namespace PlannerA.BLL;

public class Factory
{
        public string name { get; set; } = "aurora";
        public List<Order> orders { get; set; } = [];
        public List<Worker> workers { get; set; } = [];
        public List<Equipment> equipments { get; set; } = [];
        public Dictionary<Item, int> inventories { get; set; } = [];
        
        /*private async Task LoadFactoryOrdersAsync()
        {
                var factory_orders = await new OrderService().GetAllAsync();
                orders.Clear();
                foreach (var order in factory_orders)
                {
                        orders.Add(order);
                }
        }
        private async Task LoadFactoryWorkersAsync()
        {
                var factory_workers = await new WorkerService().GetAllAsync();
                workers.Clear();
                foreach (var worker in factory_workers)
                {
                        workers.Add(worker);
                }
        }
        private async Task LoadFactoryEquipmentAsync()
        {
                var factory_equipments = await new EquipmentService().GetAllAsync();
                equipments.Clear();
                foreach (var equipment in factory_equipments)
                {
                        equipments.Add(equipment);
                }
        }
        private async Task LoadFactoryInventoriesAsync()
        {
                var factory_inventories = await new ItemService().GetAllAsync();
                inventories.Clear();
                foreach (var item in factory_inventories)
                {
                        //aurora.inventories.Add(item);
                }
        }

        public Factory()
        {
                LoadFactoryOrdersAsync().ConfigureAwait(false);   
                LoadFactoryWorkersAsync().ConfigureAwait(false);
                LoadFactoryEquipmentAsync().ConfigureAwait(false);
                LoadFactoryInventoriesAsync().ConfigureAwait(false);
        }*/
}