using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class Additive
{
    public StatusGeneric Status { get; set; }
    public decimal ChipboardOrMDF { get; set; }
}