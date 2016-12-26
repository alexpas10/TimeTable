using AutoMapper;
using TimeTable.Common;
using TimeTable.Model;
using TimeTable.Web.API.ViewModel;

namespace TimeTable.Web.API.Mapping {
	public class DefaultProfile : Profile {

		public DefaultProfile() {
			CreateMap<BaseModel, BaseVM>();
			CreateMap<BaseFilter, BaseFilterVM>().ReverseMap();

			#region Room
			CreateMap<RoomFilter, RoomFilterVM>().ReverseMap();
			CreateMap<RoomDetails, RoomDetailVM>();
			CreateMap<RoomDetails, RoomDetailVM>();
			CreateMap<RoomItem, RoomItemVM>();
			CreateMap<RoomItems, RoomItemsVM>();
			CreateMap<RoomItem, SelectItemVM>()
				.ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Name));
			#endregion

			#region Teacher
			CreateMap<TeacherFilter, TeacherFilterVM>().ReverseMap();
			CreateMap<TeacherDetails, TeacherDetailVM>();
			CreateMap<TeacherDetails, TeacherDetailVM>();
			CreateMap<TeacherItem, TeacherItemVM>();
			CreateMap<TeacherItems, TeacherItemsVM>();
			CreateMap<TeacherItem, SelectItemVM>()
				.ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => Format.FormattedFullName(src.Surname, src.Name, src.Patronymic)));
			#endregion

		}
	}
}
