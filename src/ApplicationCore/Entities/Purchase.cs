using ApplicationCore.Validation;

namespace ApplicationCore.Entities;

public class Purchase
{
    public int MovieId{get;set;}
    public int UserId{get;set;}
    [PurchaseDateNotPast]
    public DateTime PurchaseDateTime{get;set;}
    public int PurchaseNumber{get;set;}
    public decimal TotalPrice{get;set;}
    
    public Movie Movie{get;set;}
    public User User{get;set;}
}