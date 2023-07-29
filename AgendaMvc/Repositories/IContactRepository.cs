using AgendaMvc.Models;

namespace AgendaMvc.Repositories
{
    public interface IContactRepository
    {
        Contact Create(Contact contact);
        List<Contact> ReadAll();
        Contact FindById(int id);
        Contact Update(Contact contact);
        bool Delete(int id);

    }
}
