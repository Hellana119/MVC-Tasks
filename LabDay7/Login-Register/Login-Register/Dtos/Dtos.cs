namespace Login_Register.Dtos;

public record  LoginDto(string UserName, string Password);
public record  RegisterDto(string UserName, string Password, string Email, DateTime DOB);

