using AutoMapper;
using System.Linq;
using TimeTable.Common;
using TimeTable.Model;
using TimeTable.Web.Context;
using TimeTable.Web.Extension;
using TimeTable.Web.ViewModel;

namespace TimeTable.Web.Mapping {
	public class DefaultProfile : Profile {

		public DefaultProfile() {
			CreateMap<BaseModel, BaseVM>();
			CreateMap<BaseFilter, BaseFilterVM>().ReverseMap();

			CreateMap<KeyValue, SelectItemVM>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Disabled, opt => opt.Ignore());

			CreateMap<DomainValue, SelectItemVM>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.ValueCode, opt => opt.MapFrom(src => src.NameCode));

			CreateMap<DomainValue, KeyValue>()
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => StyleContext.Current.Translations.Get(src.NameCode)));


			#region Room
			CreateMap<RoomFilter, RoomFilterVM>().ReverseMap();
			CreateMap<RoomDetails, RoomDetailVM>();
			CreateMap<RoomItem, RoomItemVM>();
			CreateMap<RoomItem, SelectItemVM>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => StyleFormat.FormattedRoomName(src.BuildingName, src.Name, src.PlacesCount.ToString())));
			CreateMap<RoomItems, RoomItemsVM>();
			#endregion

			#region Group
			CreateMap<GroupFilter, GroupFilterVM>().ReverseMap();
			CreateMap<GroupDetails, GroupDetailVM>();
			CreateMap<GroupItem, GroupItemVM>();
			CreateMap<GroupItem, SelectItemVM>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Name));
			CreateMap<GroupItems, GroupItemsVM>();
			#endregion

			#region Subject
			CreateMap<SubjectFilter, SubjectFilterVM>().ReverseMap();
			CreateMap<SubjectDetails, SubjectDetailVM>()
				.ForMember(dest => dest.SelectedTeachers, opt => opt.MapFrom(src => src.TeacherIds));

			CreateMap<SubjectItem, SubjectItemVM>();
			CreateMap<SubjectItem, SelectItemVM>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.ShortName));
			CreateMap<SubjectItems, SubjectItemsVM>();
			CreateMap<Subject, SubjectRefVM>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName));
			#endregion

			#region Teacher
			CreateMap<TeacherFilter, TeacherFilterVM>().ReverseMap();
			CreateMap<TeacherDetails, TeacherDetailVM>()
				.ForMember(dest => dest.SelectedSubjects, opt => opt.MapFrom(src => src.SubjectIds))
				.ForMember(dest => dest.PositionName, opt => opt.Ignore());

			CreateMap<TeacherItem, TeacherItemVM>()
				.ForMember(dest => dest.PositionName, opt => opt.Ignore());

			CreateMap<TeacherItems, TeacherItemsVM>();
			CreateMap<TeacherItem, SelectItemVM>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => Format.FormattedShortName(src.Surname, src.Name, src.Patronymic)));
			CreateMap<TeacherRefVM, SelectItemVM>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.FormattedName));
			CreateMap<Teacher, TeacherRefVM>()
				.ForMember(dest => dest.FormattedName, opt => opt.MapFrom(src => Format.FormattedFullName(src.Surname, src.Name, src.Patronymic)))
				.ForMember(dest => dest.PositionName, opt => opt.Ignore());
			#endregion

			#region Load
			CreateMap<LoadDetails, LoadDetailVM>();
			CreateMap<LoadItem, LoadItemVM>();
			CreateMap<Load, LoadItemVM>();
			CreateMap<LoadSelectItem, SelectItemVM>()
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => 
					StyleFormat.FormattedLoadName(src.TeacherName, src.SubjectName, src.SubjectTypeName, null)));
			#endregion
			
			#region Class
			CreateMap<ClassFilter, ClassFilterVM>().ReverseMap();
			CreateMap<ClassDetails, ClassDetailVM>();

			CreateMap<ClassItem, ClassItemVM>();
				//.ForMember(dest => dest.WeekAlternations, opt => opt.Ignore())
				//.ForMember(dest => dest.Days, opt => opt.Ignore())
				//.ForMember(dest => dest.Rooms, opt => opt.Ignore())
				//.ForMember(dest => dest.Loads, opt => opt.Ignore());

			CreateMap<ClassItems, ClassItemsVM>();
			#endregion
		}
	}
}
