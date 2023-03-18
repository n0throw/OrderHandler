using System.ComponentModel.DataAnnotations;
using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Data;

public class Order {
    [Key]
    public int Id { get; set; }
    public OrderMain OrderMain { get; set; }
    public DocConstructor DocConstructor { get; set; }
    public StatusGeneric DocTechnologist { get; set; }
    public DecimalSection1 Supply { get; set; }
    public DecimalSection2 SawCenter { get; set; }
    public DecimalSection1 Edge { get; set; }
    public DecimalSection1 Additive { get; set; }
    public DecimalSection1 Milling { get; set; }
    public DecimalSection1 Grinding { get; set; }
    public DecimalSection1 Press { get; set; }
    public DecimalSection1 Assembling { get; set; }
    public DecimalSection1 Packing { get; set; }
    public StatusGeneric Equipment { get; set; }
    public StatusGeneric Shipment { get; set; }
    public string Note { get; set; }
    public Mounting Mounting { get; set; }

    public Order() : this(new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), string.Empty, new()) { }
    public Order(OrderMain orderMainData,
                 DocConstructor docConstructor,
                 StatusGeneric docTechnologist,
                 DecimalSection1 supply,
                 DecimalSection2 sawCenter,
                 DecimalSection1 edge,
                 DecimalSection1 additive,
                 DecimalSection1 milling,
                 DecimalSection1 grinding,
                 DecimalSection1 press,
                 DecimalSection1 assembling,
                 DecimalSection1 packing,
                 StatusGeneric equipment,
                 StatusGeneric shipment,
                 string note,
                 Mounting mounting) {
        OrderMain = orderMainData;
        DocConstructor = docConstructor;
        DocTechnologist = docTechnologist;
        Supply = supply;
        SawCenter = sawCenter;
        Edge = edge;
        Additive = additive;
        Milling = milling;
        Grinding = grinding;
        Press = press;
        Assembling = assembling;
        Packing = packing;
        Equipment = equipment;
        Shipment = shipment;
        Note = note;
        Mounting = mounting;
    }
}
