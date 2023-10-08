﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderHandler.DB.Data.OrderAdd;

/// <summary>
/// Класс DocConst.
/// Документация Конструктор.
/// Модель БД.
/// </summary>
public class DocConst {
    /// <summary>
    /// Id в БД. Ключ записи
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Плановая дата
    /// </summary>
    [Column("dPlannedDate")]
    public DateTime PlannedDate { get; set; }
    /// <summary>
    /// Дата выполнения
    /// </summary>
    [Column("dDateOfCompletion")]
    public DateTime DateOfCompletion { get; set; }

    /// <summary>
    /// Id Пользователя.
    /// Внешний ключ
    /// </summary>
    public long IdUser { get; set; }
    /// <summary>
    /// Выполнивший пользователь.
    /// Внешний ключ
    /// </summary>
    [ForeignKey("IdUser")]
    public UserInfo? User { get; set; }
    
    /// <summary>
    /// Id Заказа.
    /// Внешний ключ
    /// </summary>
    public long? IdOrder { get; set; }
    /// <summary>
    /// Заказ.
    /// Внешний ключ
    /// </summary>
    [ForeignKey("IdOrder")]
    public OrderInfo? Order { get; set; }
}
