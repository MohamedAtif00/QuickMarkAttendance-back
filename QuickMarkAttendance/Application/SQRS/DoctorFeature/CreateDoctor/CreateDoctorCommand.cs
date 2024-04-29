using QuickMarkAttendance.Application.Abstraction;

namespace QuickMarkAttendance.Application.SQRS.DoctorFeature.CreateDoctor
{
    public record CreateDoctorCommand(Guid doctorId,string name):ICommand;
    
    
}
