using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderHandler.DB.Data;

namespace OrderHandler.DB.Configurations;
public class OrderConfiguration : IEntityTypeConfiguration<Order> {

    public void Configure(EntityTypeBuilder<Order> builder) {
        ConfigureOrderMain(builder);
        ConfigureDocConstructor(builder);
        ConfigureDocTechnologist(builder);
        ConfigureSupply(builder);
        ConfigureSawCenter(builder);
        ConfigureEdge(builder);
        ConfigureAdditive(builder);
        ConfigureMilling(builder);
        ConfigureGrinding(builder);
        ConfigurePress(builder);
        ConfigureAssembling(builder);
        ConfigurePacking(builder);
        ConfigureEquipment(builder);
        ConfigureShipment(builder);
        ConfigureNote(builder);
        ConfigureMounting(builder);
    }
    private void ConfigureOrderMain(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.OrderMain.UserId).HasColumnName("userId").HasComment("Id Менеджера заказа");
        builder.Property(u => u.OrderMain.OrderIssue).HasColumnName("issue").HasComment("Номер заказа");
        builder.Property(u => u.OrderMain.OrderDate).HasColumnName("date").HasComment("Дата заказа");
        builder.Property(u => u.OrderMain.DeliveryDate).HasColumnName("deliveryDate").HasComment("Дата доставки");
        builder.Property(u => u.OrderMain.NumberOfDays).HasColumnName("numberOfDays").HasComment("Скрок в днях");
        builder.Property(u => u.OrderMain.ProductType).HasColumnName("productType").HasComment("Тип изделия");
        builder.Property(u => u.OrderMain.ProductCost).HasColumnName("productCost").HasComment("Сумма заказа");
    }
    private void ConfigureDocConstructor(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.DocConstructor.PlannedDate).HasColumnName("docConst_PlannedDate").HasComment("Плановая дата проверки документации коноструктором");
        builder.Property(u => u.DocConstructor.UserId).HasColumnName("docConst_UserId").HasComment("Id Конструктора");
        builder.Property(u => u.DocConstructor.Date).HasColumnName("docConst_Date").HasComment("Дата проверки документации конструктором");
    }
    private void ConfigureDocTechnologist(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.DocTechnologist.PlannedDate).HasColumnName("docTech_PlannedDate").HasComment("Плановая дата проверки документации технологом");
        builder.Property(u => u.DocTechnologist.UserId).HasColumnName("docTech_UserId").HasComment("Id Технолога");
        builder.Property(u => u.DocTechnologist.Date).HasColumnName("docTech_Date").HasComment("Дата проверки документации технологом");
    }
    private void ConfigureSupply(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.Supply.Status.PlannedDate).HasColumnName("supply_PlannedDate").HasComment("Плановая дата проверки снабженцем");
        builder.Property(u => u.Supply.Status.UserId).HasColumnName("supply_UserId").HasComment("Id Снабженца");
        builder.Property(u => u.Supply.Status.Date).HasColumnName("supply_Date").HasComment("Дата проверки снабженцем");
        builder.Property(u => u.Supply.Item).HasColumnName("supply_Cost").HasComment("Необходимая сумма определённая снабженцем");
    }
    private void ConfigureSawCenter(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.SawCenter.Status.PlannedDate).HasColumnName("sawCenter_PlannedDate").HasComment("Плановая дата выполнения работ сотрудником пильного центра");
        builder.Property(u => u.SawCenter.Status.UserId).HasColumnName("sawCenter_UserId").HasComment("Id Сотрудника пильного центра");
        builder.Property(u => u.SawCenter.Status.Date).HasColumnName("sawCenter_Date").HasComment("Дата выполнения работ сотрудником пильного центра");
        builder.Property(u => u.SawCenter.Item1).HasColumnName("sawCenter_ChpipboardOrMDF").HasComment("Площадь ЛДСП/МДФ потраченных сотрудником пильного центра");
        builder.Property(u => u.SawCenter.Item2).HasColumnName("sawCenter_HDF").HasComment("Площадь ЛХДФ потраченных сотрудником пильного центра");
    }
    private void ConfigureEdge(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.Edge.Status.PlannedDate).HasColumnName("edge_PlannedDate").HasComment("Плановая дата выполнения работ кромщиком");
        builder.Property(u => u.Edge.Status.UserId).HasColumnName("edge_UserId").HasComment("Id кромщика");
        builder.Property(u => u.Edge.Status.Date).HasColumnName("edge_Date").HasComment("Дата выполнения работ кромщиком");
        builder.Property(u => u.Edge.Item).HasColumnName("edge_ChpipboardOrMDF").HasComment("Площадь ЛДСП/МДФ потраченных кромщиком");
    }
    private void ConfigureAdditive(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.Additive.Status.PlannedDate).HasColumnName("additive_PlannedDate").HasComment("Плановая дата выполнения работ присадочником");
        builder.Property(u => u.Additive.Status.UserId).HasColumnName("additive_UserId").HasComment("Id присадочника");
        builder.Property(u => u.Additive.Status.Date).HasColumnName("additive_Date").HasComment("Дата выполнения работ присадочника");
        builder.Property(u => u.Additive.Item).HasColumnName("additive_ChpipboardOrMDF").HasComment("Площадь ЛДСП/МДФ присадочника");
    }
    private void ConfigureMilling(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.Milling.Status.PlannedDate).HasColumnName("milling_PlannedDate").HasComment("Плановая дата выполнения фрезеровки");
        builder.Property(u => u.Milling.Status.UserId).HasColumnName("milling_UserId").HasComment("Id Фрезеровшика");
        builder.Property(u => u.Milling.Status.Date).HasColumnName("milling_Date").HasComment("Дата фрезеровки");
        builder.Property(u => u.Milling.Item).HasColumnName("milling_MDF").HasComment("Площадь отфрезерованного МДФ");
    }
    private void ConfigureGrinding(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.Grinding.Status.PlannedDate).HasColumnName("grinding_PlannedDate").HasComment("Плановая дата выполнения шлифовки");
        builder.Property(u => u.Grinding.Status.UserId).HasColumnName("grinding_UserId").HasComment("Id Шлифовшика");
        builder.Property(u => u.Grinding.Status.Date).HasColumnName("grinding_Date").HasComment("Дата выполнения шлифовки");
        builder.Property(u => u.Grinding.Item).HasColumnName("grinding_MDF").HasComment("Площадь отшлифованного МДФ");
    }
    private void ConfigurePress(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.Press.Status.PlannedDate).HasColumnName("press_PlannedDate").HasComment("плановая дата выполнения прессовки");
        builder.Property(u => u.Press.Status.UserId).HasColumnName("press_UserId").HasComment("Id пресовщика");
        builder.Property(u => u.Press.Status.Date).HasColumnName("press_Date").HasComment("Дата выполнения прессовки");
        builder.Property(u => u.Press.Item).HasColumnName("press_MDF").HasComment("Площадь отпрессованого МДФ");
    }
    private void ConfigureAssembling(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.Assembling.Status.PlannedDate).HasColumnName("assembling_PlannedDate").HasComment("Плановая дата сборки");
        builder.Property(u => u.Assembling.Status.UserId).HasColumnName("assembling_UserId").HasComment("Id сборщика");
        builder.Property(u => u.Assembling.Status.Date).HasColumnName("assembling_Date").HasComment("Дата сборки");
        builder.Property(u => u.Assembling.Item).HasColumnName("assembling_ChpipboardOrMDF").HasComment("Площадь собранных ЛДСП/МДФ");
    }
    private void ConfigurePacking(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.Packing.Status.PlannedDate).HasColumnName("packing_PlannedDate").HasComment("Плановая дата упаковки");
        builder.Property(u => u.Packing.Status.UserId).HasColumnName("packing_UserId").HasComment("Id упаковщика");
        builder.Property(u => u.Packing.Status.Date).HasColumnName("packing_Date").HasComment("Дата упаковки");
        builder.Property(u => u.Packing.Item).HasColumnName("packing_ChpipboardOrMDF").HasComment("Площадь упакованных ЛДСП/МДФ\"");
    }
    private void ConfigureEquipment(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.Equipment.PlannedDate).HasColumnName("equipment_PlannedDate").HasComment("Плановая дата проверки комплектации");
        builder.Property(u => u.Equipment.UserId).HasColumnName("equipment_UserId").HasComment("Id сотрудника проверяющего комплектацию");
        builder.Property(u => u.Equipment.Date).HasColumnName("equipment_Date").HasComment("Дата проверки комлектации");
    }
    private void ConfigureShipment(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.Shipment.PlannedDate).HasColumnName("shipment_PlannedDate").HasComment("Плановая дата отгрузки");
        builder.Property(u => u.Shipment.UserId).HasColumnName("shipment_UserId").HasComment("Id отгрузившего сотрудника");
        builder.Property(u => u.Shipment.Date).HasColumnName("shipment_Date").HasComment("Дата отгрузки");
    }
    private void ConfigureNote(EntityTypeBuilder<Order> builder) =>
        builder.Property(u => u.Note).HasColumnName("note").HasComment("Примечание");
    private void ConfigureMounting(EntityTypeBuilder<Order> builder) {
        builder.Property(u => u.Mounting.IsMounting).HasColumnName("isMounting").HasComment("Нужен ли монтаж");
        builder.Property(u => u.Mounting.Date).HasColumnName("date").HasComment("Дата монтажа");
    }
}