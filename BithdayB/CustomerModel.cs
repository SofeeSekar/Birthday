using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BithdayB;
public class CustomerModel
{
  /// <summary>
  /// Gets or Sets the Id
  /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Gets or Sets the Address
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// Gets or Sets the Date
    /// </summary>
    public DateTime Date { get; set; }

}
public class LoginModel
{
    /// <summary>
    /// Gets or Sets the email
    /// </summary>
    public string email { get; set; }
    /// <summary>
    /// Gets or Sets the password
    /// </summary>
    public List<Password> password { set; get; }
    /// <summary>
    /// Gets or Sets the token
    /// </summary>
    public string token { get; set; }

}

public class Password
{
    /// <summary>
    /// Gets or Sets the value
    /// </summary>
    public string value { get; set; }

}