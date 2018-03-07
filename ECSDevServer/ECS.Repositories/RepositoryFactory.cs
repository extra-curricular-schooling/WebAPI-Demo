using ECS.Models;
using ECS.Models.ECSContext;

namespace ECS.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {

    }

    public interface IAccountTypeRepository : IRepository<AccountType>
    {

    }

    public interface IArticleRepository : IRepository<Article>
    {

    }

    public interface IInterestTagRepository : IRepository<InterestTag>
    {

    }

    public interface ILinkedInRepository : IRepository<LinkedIn>
    {

    }

    public interface ISecurityQuestionRepository : IRepository<SecurityQuestion>
    {

    }

    public interface ISecurityQuestionAccountRepository : IRepository<SecurityQuestionAccount>
    {

    }

    public interface ISweepStakeRepository : IRepository<SweepStake>
    {

    }

    public interface ISweepStakeEntryRepository : IRepository<SweepStakeEntry>
    {

    }

    public interface ITokenRepository : IRepository<Token>
    {

    }

    public interface IUserRepository : IRepository<User>
    {

    }

    public interface IZipLocationRepository : IRepository<ZipLocation>
    {

    }

    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository()
        : base(new ECSContext())
        {
        }
    }

    public class AccountTypeRepository : Repository<AccountType>, IAccountTypeRepository
    {

        public AccountTypeRepository()
        : base(new ECSContext())
        {
        }

    }

    public class ArticleRepository : Repository<Article>, IArticleRepository
    {

        public ArticleRepository()
        : base(new ECSContext())
        {
        }

    }

    public class InterestTagRepository : Repository<InterestTag>, IInterestTagRepository
    {

        public InterestTagRepository()
        : base(new ECSContext())
        {
        }

    }

    public class LinkedInRepository : Repository<LinkedIn>, ILinkedInRepository
    {

        public LinkedInRepository()
        : base(new ECSContext())
        {
        }

    }

    public class SecurityQuestionRepository : Repository<SecurityQuestion>, ISecurityQuestionRepository
    {

        public SecurityQuestionRepository()
        : base(new ECSContext())
        {
        }

    }

    public class SecurityQuestionAccountRepository : Repository<SecurityQuestionAccount>, ISecurityQuestionAccountRepository
    {

        public SecurityQuestionAccountRepository()
        : base(new ECSContext())
        {
        }

    }

    public class SweepStakeRepository : Repository<SweepStake>, ISweepStakeRepository
    {

        public SweepStakeRepository()
        : base(new ECSContext())
        {
        }

    }

    public class SweepStakeEntryRepository : Repository<SweepStakeEntry>, ISweepStakeEntryRepository
    {

        public SweepStakeEntryRepository()
        : base(new ECSContext())
        {
        }

    }

    public class TokenRepository : Repository<Token>, ITokenRepository
    {

        public TokenRepository()
        : base(new ECSContext())
        {
        }

    }

    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository()
        : base(new ECSContext())
        {
        }

    }

    public class ZipLocationRepository : Repository<ZipLocation>, IZipLocationRepository
    {

        public ZipLocationRepository()
        : base(new ECSContext())
        {
        }

    }
}
