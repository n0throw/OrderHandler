using OrderHandler.DB.Model.Additional.Order;
using System.ComponentModel.DataAnnotations;

namespace OrderHandler.DB.Model;

public class Order
{
    [Key]
    public int Id { get; set; }
    public OrderMainData OrderMainData { get; set; }
    public StatusGeneric DocumentationConstructor { get; set; }
    public StatusGeneric DocumentationTechnologist { get; set; }
    public Supply Supply { get; set; }
    public SawCenter SawCenter { get; set; }
    public Edge Edge { get; set; }
    public Additive Additive { get; set; }
    public Milling Milling { get; set; }
    public Grinding Grinding { get; set; }
    public Press Press { get; set; }
    public Assembling Assembling { get; set; }
    public Packaging Packaging { get; set; }
    public StatusGeneric Equipment { get; set; }
    public StatusGeneric Shipment { get; set; }
    public string? Note { get; set; }
    public Mounting Mounting { get; set; }

    public Order(
        int id,
        OrderMainData orderMainData,
        StatusGeneric documentationConstructor,
        StatusGeneric documentationTechnologist,
        Supply supply,
        SawCenter sawCenter,
        Edge edge,
        Additive additive,
        Milling milling,
        Grinding grinding,
        Press press,
        Assembling assembling,
        Packaging packaging,
        StatusGeneric equipment,
        StatusGeneric shipment,
        string? note,
        Mounting mounting)
    {
        Id = id;
        OrderMainData = orderMainData;
        DocumentationConstructor = documentationConstructor;
        DocumentationTechnologist = documentationTechnologist;
        Supply = supply;
        SawCenter = sawCenter;
        Edge = edge;
        Additive = additive;
        Milling = milling;
        Grinding = grinding;
        Press = press;
        Assembling = assembling;
        Packaging = packaging;
        Equipment = equipment;
        Shipment = shipment;
        Note = note;
        Mounting = mounting;
    }
}
