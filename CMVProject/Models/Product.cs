namespace CMVProject.Models;
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key] public int Id { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Provider { get; set; } = string.Empty;
    public User? Storekeeper { get; set; }
    
    [MaxLength(100)]
    public string DeliveryDate { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string AccountingDate { get; set; } = string.Empty;
}