using ECS.Models;
using ECS.Models.ECSContext;

namespace ECS.Repositories
{
    /// <summary>
    /// Account Repository Interface for Account Models
    /// </summary>
    public interface IAccountRepository : IRepositoryBase<Account>
    {
    }

    /// <summary>
    /// AccountType Repository Interface for AccountType ModelsC:\Users\simpo\source\repos\dev-webapi\ECSDevServer\ECS.Repositories\ConcreteRepositories.cs
    /// </summary>
    public interface IAccountTypeRepository : IRepositoryBase<AccountType>
    {
    }

    /// <summary>
    /// Article Repository Interface for Article Models
    /// </summary>
    public interface IArticleRepository : IRepositoryBase<Article>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IInterestTagRepository : IRepositoryBase<InterestTag>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IJwtRepository: IRepositoryBase<JWT>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ILinkedInRepository : IRepositoryBase<LinkedIn>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ISecurityQuestionRepository : IRepositoryBase<SecurityQuestion>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ISecurityQuestionAccountRepository : IRepositoryBase<SecurityQuestionAccount>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ISweepStakeRepository : IRepositoryBase<SweepStake>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ISweepStakeEntryRepository : IRepositoryBase<SweepStakeEntry>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ITokenRepository : IRepositoryBase<Token>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IUserRepository : IRepositoryBase<User>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IZipLocationRepository : IRepositoryBase<ZipLocation>
    {
    }

    /// <summary>
    /// Account Repository using ECS DbContext connection
    /// </summary>
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository() : base(new ECSContext())
        {
        }
    }

    /// <summary>
    /// AccountType Repository using ECS DbContext connection
    /// </summary>
    public class AccountTypeRepository : RepositoryBase<AccountType>, IAccountTypeRepository
    {
        public AccountTypeRepository() : base(new ECSContext())
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository() : base(new ECSContext())
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class InterestTagRepository : RepositoryBase<InterestTag>, IInterestTagRepository
    {
        public InterestTagRepository() : base(new ECSContext())
        {
        }
    }

    public class JwtRepository : RepositoryBase<JWT>, IJwtRepository
    {
        public JwtRepository () : base (new ECSContext())
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class LinkedInRepository : RepositoryBase<LinkedIn>, ILinkedInRepository
    {
        public LinkedInRepository() : base(new ECSContext())
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SecurityQuestionRepository : RepositoryBase<SecurityQuestion>, ISecurityQuestionRepository
    {
        public SecurityQuestionRepository() : base(new ECSContext())
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SecurityQuestionAccountRepository : RepositoryBase<SecurityQuestionAccount>, ISecurityQuestionAccountRepository
    {
        public SecurityQuestionAccountRepository() : base(new ECSContext())
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SweepStakeRepository : RepositoryBase<SweepStake>, ISweepStakeRepository
    {
        public SweepStakeRepository() : base(new ECSContext())
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SweepStakeEntryRepository : RepositoryBase<SweepStakeEntry>, ISweepStakeEntryRepository
    {
        public SweepStakeEntryRepository() : base(new ECSContext())
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TokenRepository : RepositoryBase<Token>, ITokenRepository
    {
        public TokenRepository() : base(new ECSContext())
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository() : base(new ECSContext())
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ZipLocationRepository : RepositoryBase<ZipLocation>, IZipLocationRepository
    {
        public ZipLocationRepository() : base(new ECSContext())
        {
        }
    }
}
