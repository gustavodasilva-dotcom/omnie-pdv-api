﻿using OmniePDV.API.Data.Entities;
using OmniePDV.API.Entities;
using System.Text.Json.Serialization;

namespace OmniePDV.API.Models.ViewModels;

public sealed class SaleViewModel
{
    [JsonPropertyName("uid")]
    public Guid UID { get; set; }

    [JsonPropertyName("subtotal")]
    public double Subtotal { get; set; }

    [JsonPropertyName("discount")]
    public double Discount { get; set; }

    [JsonPropertyName("total")]
    public double Total { get; set; }

    [JsonPropertyName("products")]
    public List<SaleProductViewModel> Products { get; set; }

    [JsonPropertyName("status")]
    public SaleStatus Status { get; set; }

    [JsonPropertyName("sale_date")]
    public DateTime SaleDate { get; set; }
}

public static class SaleViewModelExtensions
{
    public static SaleViewModel ToViewModel(this Sale model) => new()
    {
        UID = model.UID,
        Subtotal = model.Subtotal,
        Discount = model.Discount,
        Total = model.Total,
        Products = model.Products.ToViewModel(),
        Status = model.Status,
        SaleDate = model.SaleDate
    };

    public static List<SaleViewModel> ToViewModel(this List<Sale> model) =>
        model.Select(m => m.ToViewModel()).ToList();
}
