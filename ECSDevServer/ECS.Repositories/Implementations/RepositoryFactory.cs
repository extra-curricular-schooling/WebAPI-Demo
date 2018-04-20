using ECS.Models;
using ECS.Repositories.Contracts;

namespace ECS.Repositories.Implementations
{
    /// <summary>
    /// Account Repository Interface for Account Models
    /// </summary>
    public interface IAccountRepository : IRepositoryBase<Account>
    {
    }

    /// <summary>
    /// AccountType Repository Interface for AccountType Models
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
    public interface IBadAccessTokenRepository : IRepositoryBase<BadAccessToken>
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
    public interface IJAccessTokenRepository: IRepositoryBase<JAccessToken>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ILinkedInAccessTokenRepository: IRepositoryBase<LinkedInAccessToken>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IPartialAccountRepository : IRepositoryBase<PartialAccount>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IPartialAccountSaltRepository : IRepositoryBase<PartialAccountSalt>
    {

    }


    /// <summary>
    /// 
    /// </summary>
    public interface ISaltRepository: IRepositoryBase<Salt>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ISaltSecurityAnswerRepository : IRepositoryBase<SaltSecurityAnswer>
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
    public interface IExpiredAccessTokenRepository : IRepositoryBase<ExpiredAccessToken>
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
    public interface IUserProfileRepository : IRepositoryBase<UserProfile>
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
    public class BadAccessTokenRepository : RepositoryBase<BadAccessToken>, IBadAccessTokenRepository
    {
        public BadAccessTokenRepository() : base(new ECSContext())
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
    public class JAccessTokenRepository : RepositoryBase<JAccessToken>, IJAccessTokenRepository
    {
        public JAccessTokenRepository () : base (new ECSContext())
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class LinkedInAccessTokenRepository: RepositoryBase<LinkedInAccessToken>, ILinkedInAccessTokenRepository
    {
        public LinkedInAccessTokenRepository () : base (new ECSContext())
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PartialAccountRepository : RepositoryBase<PartialAccount>, IPartialAccountRepository
    {
        public PartialAccountRepository() : base(new ECSContext())
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PartialAccountSaltRepository : RepositoryBase<PartialAccountSalt>, IPartialAccountSaltRepository
    {
        public PartialAccountSaltRepository() : base(new ECSContext())
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SaltRepository : RepositoryBase<Salt>, ISaltRepository
    {
        public SaltRepository() : base(new ECSContext())
        {
        }
    }

    public class SaltSecurityAnswerRepository : RepositoryBase<SaltSecurityAnswer>, ISaltSecurityAnswerRepository
    {
        public SaltSecurityAnswerRepository() : base(new ECSContext())
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
    public class ExpiredAccessTokenRepository : RepositoryBase<ExpiredAccessToken>, IExpiredAccessTokenRepository
    {
        public ExpiredAccessTokenRepository() : base(new ECSContext())
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
    public class UserProfileRepository : RepositoryBase<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository() : base(new ECSContext())
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
