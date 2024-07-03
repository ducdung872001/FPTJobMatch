using System.Numerics;

namespace FPTJobMatch.Models
{
    public class AspNetUsers
    {
        private int Id { get; set; } 
        private string UserName { get; set; }
        private string NormalizedUserName {  get; set; }
        private string Email {  get; set; }
        private string NormalizedEmail {  get; set; }
        private bool EmailConfirmed {  get; set; }
        private string PasswordHash { get; set; }
        private string SecurityStamp { get; set; }
        private string ConcurrencyStamp { get; set; }
        private int PhoneNumber { get; set; }
        private bool PhoneNumberConfirmed { get; set; }
        private bool TwoFactorEnabled { get; set; }
        private DateTime LockoutEnd {  get; set; }
        private bool LockoutEnabled {  get; set; }
        private int AccessFailedCount {  get; set; }
    }
}