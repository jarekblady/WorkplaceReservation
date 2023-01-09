using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WorkplaceReservation.Repository.Entities;
using WorkplaceReservation.Service.DTOs;

namespace WorkplaceReservation.Service
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(m => m.FullName, c => c.MapFrom(s => s.FirstName + " " + s.LastName));
            CreateMap<EmployeeDto, Employee>();

            CreateMap<EquipmentForWorkplace, EquipmentForWorkplaceDto>()
                .ForMember(d => d.Type, c => c.MapFrom(s => s.Equipment.Type))
                .ForMember(d => d.WorkplaceName, c => c.MapFrom(s => "Floor: " + s.Workplace.Floor + ", Room: " + s.Workplace.Room + ", Table: " + s.Workplace.Table));
            CreateMap<EquipmentForWorkplaceDto, EquipmentForWorkplace>();
            
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<EquipmentDto, Equipment>();

            CreateMap<Reservation, ReservationDto>()
                .ForMember(d => d.FirstName, c => c.MapFrom(s => s.Employee.FirstName))
                .ForMember(d => d.LastName, c => c.MapFrom(s => s.Employee.LastName))
                .ForMember(m => m.FullName, c => c.MapFrom(s => s.Employee.FirstName + " " + s.Employee.LastName))
                .ForMember(d => d.Floor, c => c.MapFrom(s => s.Workplace.Floor))
                .ForMember(d => d.Room, c => c.MapFrom(s => s.Workplace.Room))
                .ForMember(d => d.Table, c => c.MapFrom(s => s.Workplace.Table))
                .ForMember(d => d.WorkplaceName, c => c.MapFrom(s => "Floor: " + s.Workplace.Floor + ", Room: " + s.Workplace.Room + ", Table: " + s.Workplace.Table));
            CreateMap<ReservationDto, Reservation>();

            CreateMap<Workplace, WorkplaceDto>()
                .ForMember(m => m.WorkplaceName, c => c.MapFrom(s => "Floor: " + s.Floor + ", Room: " + s.Room + ", Table: " + s.Table));
            CreateMap<WorkplaceDto, Workplace>();

        }
    }
}
