using AutoMapper;
using TimeTable.Common.AppConstants;
using TimeTable.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Model;
using TimeTable.Web.API.ViewModel;
using TimeTable.Common;

namespace TimeTable.Web.API.Controllers {

	[Route("api/[controller]")]

	public class TeacherController : Controller {
		private IMapper _mapper { get; set; }
		private ITeacherRepository _teacherRepository;
		private IDomainValueRepository _domainValueRepository;

		public TeacherController(ITeacherRepository teacherRepository, IMapper mapper, IDomainValueRepository domainValueRepository) {
			_mapper = mapper;
			_teacherRepository = teacherRepository;
			_domainValueRepository = domainValueRepository;
		}

		[HttpGet]
		public TeacherItemsVM Get([FromQuery]TeacherFilter filter) {
			return _mapper.Map<TeacherItemsVM>(_teacherRepository.GetTeacherItems(filter));
		}

		[HttpGet("{id}", Name = "GetTeacher")]
		public IActionResult Get(int id) {
			var details = _teacherRepository.GetTeacherDetails(id);
			if (details != null) {
				return new JsonResult(_mapper.Map<TeacherDetailVM>(details));
			} else {
				return new NotFoundResult();
			}
		}

		[HttpPut("{id}")]
		public IActionResult Put([FromBody]TeacherCreateVM newTeacherVM) {
			if (!_domainValueRepository.CheckDomainValueOfType(newTeacherVM.PositionId, Dom.DomainValueType.TeachersPosition)) {
				ModelState.AddModelError("Error", "Incorrect positionId parameter");
			}
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}
			var Teacher = _teacherRepository.GetEntity<Teacher>(newTeacherVM.Id);
			if (Teacher == null) {
				return NotFound();
			}
			_teacherRepository.AddOrUpdate(new Teacher {
				Id = newTeacherVM.Id,
				Name = newTeacherVM.Name,
				Patronymic = newTeacherVM.Patronymic,
				Surname = newTeacherVM.Surname,
				PositionId = newTeacherVM.PositionId
			});
			if (!newTeacherVM.SubjectIds.IsNullOrEmpty()) {
				foreach (var subjectId in newTeacherVM.SubjectIds) {
					if (!_teacherRepository.HasSubject(newTeacherVM.Id, subjectId)) {
						_teacherRepository.AddOrUpdate(new SubjectTeacher {
							TeacherId = newTeacherVM.Id,
							SubjectId = subjectId
						});
					}
				}
			}

			_teacherRepository.UnitOfWork.SaveChanges();
			return new NoContentResult();
		}

		[HttpPost]
		public IActionResult Create([FromBody]TeacherCreateVM newTeacherVM) {
			if (!_domainValueRepository.CheckDomainValueOfType(newTeacherVM.PositionId, Dom.DomainValueType.TeachersPosition)) {
				ModelState.AddModelError("Error", "Incorrect positionId parameter");
			}
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			} else {
				var newTeacher = _teacherRepository.Add(
					new Teacher {
						Name = newTeacherVM.Name,
						Patronymic = newTeacherVM.Patronymic,
						Surname = newTeacherVM.Surname,
						PositionId = newTeacherVM.PositionId
					}
				);
				_teacherRepository.UnitOfWork.SaveChanges();
				if (!newTeacherVM.SubjectIds.IsNullOrEmpty()) {
					foreach (var subjectId in newTeacherVM.SubjectIds) {
						_teacherRepository.Add(new SubjectTeacher {
							TeacherId = newTeacher.Entity.Id,
							SubjectId = subjectId
						});
					}
				}
				_teacherRepository.UnitOfWork.SaveChanges();
				return CreatedAtRoute("GetTeacher", new { id = newTeacher.Entity.Id }, newTeacherVM);
			}
		}

		// DELETE api/Teacher/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id) {
			var teacher = _teacherRepository.GetEntity<Teacher>(id);
			if (teacher == null) {
				return NotFound();
			}
			_teacherRepository.Delete(teacher);
			_teacherRepository.UnitOfWork.SaveChanges();
			return new NoContentResult();
		}
	}
}