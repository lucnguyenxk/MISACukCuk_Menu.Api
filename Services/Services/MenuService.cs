using Services.Commons.Enums;
using Services.Commons.Exceptions;
using Services.Entities;
using Services.Interfaces.IRespository;
using Services.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MenuService : BaseService<Menu> ,IMenuService
    {
        #region Properties
        IMenuRepository iMenuRepository;
        IBaseRepository<ServiceHobby> iServiceHobbyRepository;
        #endregion
        #region Constructor
        public MenuService(IMenuRepository _iMenuRepository, IBaseRepository<ServiceHobby> _iServiceHobbyRepository) : base(_iMenuRepository)
        {
            iMenuRepository = _iMenuRepository;
            iServiceHobbyRepository = _iServiceHobbyRepository;
        }
        #endregion
        #region Methods

        /// <summary>
        /// Kiểm tra đối tượng có details hay không , có thì thực hiện kiểm tra và thêm vào db
        /// </summary>
        /// <param name="entity"> đối tượng cần kiểm tra</param>
        /// <returns> số đối tượng được thêm vào</returns>
        public override int Insert(Menu entity)
        {
            // lấy id mới cho đối tượng master thực đơn
            var newId = Guid.NewGuid();
            entity.MenuId = newId;
            // thêm dữ liệu của thực đơn(master)
            if (entity.ListServiceHobby.Count > 0)
            {
                return InsertOrUpDateMenu(entity);
                ////Biến tính tổng số lượng đối tượng được thêm vào
                //var numberOfMenuInsert=0;
                //// validate đối tượng 
                //base.Validate(entity);
                //// Kiểm tra và lấy về đối tượng con của thực đơn;
                //var listChildObjects = CheckObjectChildren(entity);
                
                //// tách riêng cha con để thêm vào bảng
                //entity.ListServiceHobby = null;
                
                //// lấy id của cha cho con
                //foreach(var child in listChildObjects)
                //{
                //    child.MenuId = entity.MenuId;
                //}
                //// thêm mới thực đơn master
                //numberOfMenuInsert = iMenuRepository.Insert(entity);
                //// thêm mới đối tượng con
                //numberOfMenuInsert += iServiceHobbyRepository.InsertList(listChildObjects, "ServiceHobbyToMenu");
                //return numberOfMenuInsert;

            }
            else
            {
                return base.Insert(entity);
            }
        }

        public override int Update(Guid id, Menu entity)
        {
            entity.EntityState = EntityState.Update;
            if(entity.ListServiceHobby.Count > 0)
            {
                return InsertOrUpDateMenu(entity);  
            }
            else
            {
                iServiceHobbyRepository.DeleteById(id,"ServiceHobbyToMenu","Menu");
                return base.Update(id, entity);
            }
            
        }

        /// <summary>
        /// Kiểm tra những sở thích phục vụ mới được cập nhật
        /// </summary>
        ///<return>trả về danh sách những sở thích phục vụ mới</return>
        /// created by (09/07/2021)
        private List<ServiceHobby> GetNewServiceHobby(List<ServiceHobby> listServiceHobbys)
        {
            var newListServiceHobby = new List<ServiceHobby>();
            var allServiceHobby = iServiceHobbyRepository.GetAll();
            foreach(var serviceHobby in listServiceHobbys)
            {
                if ((serviceHobby.ServiceHobbyName == "" || serviceHobby.ServiceHobbyName == null) && (serviceHobby.PriceAdd != 0 && serviceHobby.PriceAdd != null))
                {
                    throw new ValidateException("Sở thích phục vụ không được bỏ trống khi có thu thêm");
                }
                var isExistServiceHobby = allServiceHobby.Where(item => (item.ServiceHobbyName == serviceHobby.ServiceHobbyName && item.PriceAdd == serviceHobby.PriceAdd));
                if(isExistServiceHobby.Count()==0)
                {
                    // sinh ra id mới cho sở thích phục vụ mới.
                    var newId = Guid.NewGuid();
                    serviceHobby.ServiceHobbyId = newId;
                    newListServiceHobby.Add(serviceHobby);
                }
                else
                {
                    //Kiểm tra xem id của sở thích phục vụ đã đúng chưa, chưa thì gán lại
                    if(serviceHobby.ServiceHobbyId == Guid.Empty || serviceHobby.ServiceHobbyId != isExistServiceHobby.ToList()[0].ServiceHobbyId)
                    {
                        serviceHobby.ServiceHobbyId = isExistServiceHobby.ToList()[0].ServiceHobbyId;
                    } 

                }
            }
            return newListServiceHobby;
        }

        /// <summary>
        /// Kiểm tra xem đối tượng có các đối tượng con hay không.
        /// </summary>
        /// created by ndluc(09/07/2021)
        public List<ServiceHobby> CheckObjectChildren(Menu entity)
        {
            // kiểm tra xem nếu có sở thích phục vụ thì thêm vào(details)
            if (entity.ListServiceHobby.Count > 0)
            {
                // kiểm tra những sở thích phục vụ mới- get all sở thích phục vụ ra để kiểm tra, lấy ra những sở thích phục vụ mới.
                var newListServiceHobby = GetNewServiceHobby(entity.ListServiceHobby);
                // có danh sở thích phục vụ mới thì thêm vào db luôn
                if(newListServiceHobby.Count() > 0)
                {
                    iServiceHobbyRepository.InsertList(newListServiceHobby);
                }
            }
            return entity.ListServiceHobby;
        }

        /// <summary>
        /// Hàm dùng chung cho việc thêm hoặc sửa  đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm hoặc sửa</param>
        /// <returns>Số lượng đối tượng được thêm hoặc sửa</returns>
        /// created by ndluc(10/07/2021)
        private  int InsertOrUpDateMenu(Menu entity)
        {
            //Biến tính tổng số lượng đối tượng được thêm vào
            var numberOfMenuInsert = 0;
            // validate đối tượng 
            base.Validate(entity);
            // Kiểm tra và lấy về đối tượng con của thực đơn;
            var listChildObjects = CheckObjectChildren(entity);

            // tách riêng cha con để thêm vào bảng
            entity.ListServiceHobby = null;

            // lấy id của cha cho con
            foreach (var child in listChildObjects)
            {
                child.MenuId = entity.MenuId;
            }
            // thêm mới hoặc sửa thực đơn master
            if(entity.EntityState == EntityState.Add)
            {
                numberOfMenuInsert = iMenuRepository.Insert(entity);
            }
            else if(entity.EntityState == EntityState.Update)
            {
                iServiceHobbyRepository.DeleteById(entity.MenuId, "ServiceHobbyToMenu","Menu");
                numberOfMenuInsert = iMenuRepository.Update(entity.MenuId, entity);
            }
            // thêm mới đối tượng con
            numberOfMenuInsert += iServiceHobbyRepository.InsertList(listChildObjects, "ServiceHobbyToMenu");
            return numberOfMenuInsert;
        }


        public override int Delete(Guid id)
        {
            var res = iServiceHobbyRepository.DeleteById(id, "ServiceHobbyToMenu", "Menu");
            res += base.Delete(id);
            return res;
        }
        #endregion
    }
}
