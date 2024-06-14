using System.ComponentModel.DataAnnotations;

namespace CMVProject.Models;

public class User
{
    [Key] public int Id { get; set; }
    
    [MaxLength(100)]
    public string? Login { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Password { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Surname { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Patronymic { get; set; } = string.Empty;
    
    public override bool Equals(object? obj)
    {
        var other = obj as User;
        return other?.Login == Login;
    }
    
    // ReSharper disable once NonReadonlyMemberInGetHashCode
    public override int GetHashCode() => Login?.GetHashCode() ?? 0;
    
    public override string ToString() => $"{Surname} {Name} {Patronymic} ({Login})";
}