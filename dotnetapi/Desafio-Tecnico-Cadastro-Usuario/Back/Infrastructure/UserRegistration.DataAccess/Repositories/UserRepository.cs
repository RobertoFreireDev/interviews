using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRegistration.Domain.Entities;
using UserRegistration.DataAccess.Repositories.Base;
using UserRegistration.Domain.Repositories;
using UserRegistration.Domain.Dtos.User;
using UserRegistration.Domain.Enums.User;
using UserRegistration.DataAccess.Utils;

namespace UserRegistration.DataAccess.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) {}

        public Task<IEnumerable<UserEntity>> GetUsersAsync(UserFilterDto userfilter = null)
        {
            string queryFilter = BuildFilter(userfilter);

            string query = $@"SELECT 
                                USER_ID AS Id,
                                NAME,
                                BIRTHDATE,
                                EMAIL,
                                ACTIVE,
                                GENDERID,
                                DESCRIPTION AS Gender
                              FROM UR_USER U
                              JOIN UR_GENDER G ON G.GENDER_ID = U.GENDERID
                              {queryFilter}
                            ";

            return ExecuteAsync(query);
        }

        public async Task<int> ToggleActivationInUserAsync(UserToggleActivationDto userToggleActivationDto)
        {
            string query = $@"UPDATE UR_USER SET ACTIVE = {BoolUtil.ConvertBoolToString(userToggleActivationDto.Active)}
                              WHERE USER_ID = @UserId
                            ";
            return await UpdateAsync(query,("@UserId", userToggleActivationDto.Id));
        }

        public async Task<int> EditUserAsync(UserEntity user)
        {

            string query = $@"DECLARE @Feminino AS uniqueidentifier
                            SELECT @Feminino = [GENDER_ID] FROM UR_GENDER WHERE DESCRIPTION = 'Feminino'

                            DECLARE @Masculino AS uniqueidentifier
                            SELECT @Masculino = [GENDER_ID] FROM UR_GENDER WHERE DESCRIPTION = 'Masculino'
                                
                                UPDATE UR_USER SET 
                                NAME = @Name,
                                BIRTHDATE = @BirthDate,
                                EMAIL = @Email,
                                PASSWORD = @Password,
                                ACTIVE = @Active,
                                GENDERID = {( user.Gender == GenderEnum.Masculino.ToString() ? "@Masculino" : "@Feminino" )}
                            WHERE USER_ID = @Id";
            return await UpdateAsync(user, query);
        }
                    
        public async Task<bool> AddUserAsync(UserEntity user)
        {
            string query = $@"DECLARE @Feminino AS uniqueidentifier
                            SELECT @Feminino = [GENDER_ID] FROM UR_GENDER WHERE DESCRIPTION = 'Feminino'

                            DECLARE @Masculino AS uniqueidentifier
                            SELECT @Masculino = [GENDER_ID] FROM UR_GENDER WHERE DESCRIPTION = 'Masculino'
                                
                            INSERT INTO UR_USER 
							   (USER_ID,NAME,BIRTHDATE,EMAIL,PASSWORD,ACTIVE,GENDERID)
						    VALUES
							   (NEWID(),@Name,@BirthDate,@Email,@Password,@Active,
                            {( user.Gender == GenderEnum.Masculino.ToString() ? "@Masculino" : "@Feminino" )}
                            )";
            await AddAsync(user, query);
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            string query = $@"DELETE UR_USER WHERE USER_ID = '{id}'";
            await DeleteAsync(query);            
            return true;
        }

        private string BuildFilter(UserFilterDto userfilter)
        {
            if (userfilter == null || userfilter.Filters.Length == 0) return "";

            var filterList = new List<string>();

            Filter nameFilter = userfilter.Filters.FirstOrDefault(f => f.Field == FieldTypeEnum.Name.ToString());
            if (nameFilter != null && !String.IsNullOrWhiteSpace(nameFilter.Value))
            {
                filterList.Add($@"U.NAME LIKE '%{nameFilter.Value}%'");
            }

            Filter activeFilter = userfilter.Filters.FirstOrDefault(f => f.Field == FieldTypeEnum.Active.ToString());
            if (activeFilter != null)
            {
                filterList.Add($@"U.ACTIVE = {BoolUtil.ConvertBoolToString(activeFilter.Value == ActiveEnum.Ativo.ToString())}");
            }       

            return filterList?.Count > 0 ? "Where " + filterList.Aggregate((a, b) => a + " AND " + b) : "";
        }
    }
}

