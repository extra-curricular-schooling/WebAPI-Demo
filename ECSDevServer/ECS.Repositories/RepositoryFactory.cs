using ECS.Models;
using ECS.Models.ECSContext;

namespace ECS.Repositories
{
    /// <summary>
    /// Account Repository Interface for Account Models
    /// </summary>
    public interface IAccountRepository : IRepository<Account>
    {
    }

    /// <summary>
    /// AccountType Repository Interface for AccountType Models
    /// </summary>
    public interface IAccountTypeRepository : IRepository<AccountType>
    {
    }

    /// <summary>
    /// Article Repository Interface for Article Models
    /// </summary>
    public interface IArticleRepository : IRepository<Article>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IInterestTagRepository : IRepository<InterestTag>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ILinkedInRepository : IRepository<LinkedIn>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ISecurityQuestionRepository : IRepository<SecurityQuestion>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ISecurityQuestionAccountRepository : IRepository<SecurityQuestionAccount>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ISweepStakeRepository : IRepository<SweepStake>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ISweepStakeEntryRepository : IRepository<SweepStakeEntry>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ITokenRepository : IRepository<Token>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IZipLocationRepository : IRepository<ZipLocation>
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
