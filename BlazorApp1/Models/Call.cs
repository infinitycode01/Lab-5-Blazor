using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models;

[Table("calls")]
public class Call
{
    [Key]
    [Column("call_id")]
    public int CallId { get; set; }
    
    //[Required]
    //[ForeignKey("Phone")]
    [Column("phone_id")]
    public int PhoneId { get; set; }
    
    //[Required]
    //[ForeignKey("City")]
    [Column("city_id")]
    public int CityId { get; set; }

    //[Required]
    [Column("call_date")]
    public DateOnly Date { get; set; }

    //[Required]
    [Column("call_duration")]
    public int Duration { get; set; }
    
    //[Required]
    //[ForeignKey("Tariff")]
    [Column("tariff_id")]
    public int TariffId { get; set; }

    public override string ToString()
    {
        return $"CallId: {CallId}, PhoneId: {PhoneId}, CityId: {CityId}, Date: {Date}, Duration: {Duration}, TariffId: {TariffId};";
    }
}