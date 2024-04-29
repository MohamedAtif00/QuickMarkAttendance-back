namespace QuickMarkAttendance.Application.DTOs.Authentication.request
{
    public record RegisterRequest(string username,string email,string password,string ip);
    public record DoctorRegisterRequest(string username, string email, string password);

}
