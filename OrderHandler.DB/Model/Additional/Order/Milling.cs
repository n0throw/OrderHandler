﻿using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class Milling
{
    public StatusGeneric Status { get; set; }
    public decimal MDF { get; set; }
}