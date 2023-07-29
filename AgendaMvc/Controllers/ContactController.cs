using AgendaMvc.Models;
using AgendaMvc.Repositories;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AgendaMvc.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {

            var contacts = _contactRepository.ReadAll();

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contact.CreatedAt = DateTime.Now;
                    _contactRepository.Create(contact);

                    TempData["Success"] = "Contato cadastrado com sucesso";


                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Não conseguimos cadastrar seu contato, tente novamente, detalhe do erro: {ex.Message}";

                return RedirectToAction("Index");
            }

        }

        public IActionResult Detail(int id)
        {
            var contact = _contactRepository.FindById(id);

            return View(contact);
        }

        public IActionResult Update(int id)
        {
            var contact = _contactRepository.FindById(id);

            return View(contact);
        }

        [HttpPost]
        public IActionResult Update(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contact.UpdateAt = DateTime.Now;
                    _contactRepository.Update(contact);

                    // TempData["ToastMessage"] = "Contato atualizado com sucesso!";
                    // TempData["ToastType"] = "success";

                    return RedirectToAction("Index");

                }

                return View(contact);

            }
            catch (Exception ex)
            {
                // TempData["ToastMessage"] = $"Não conseguimos atualizar seu contato, tente novamente, detalhe do erro: {ex.Message}";
                // TempData["ToastType"] = "error";

                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int id)
        {
            var contact = _contactRepository.FindById(id);

            return View(contact);
        }

        public IActionResult DeleteContact(int id)
        {
            try
            {
                bool delete = _contactRepository.Delete(id);

                if (delete)
                {
                    //TempData["ToastMessage"] = "Contato apagado com sucesso!";
                    // TempData["ToastType"] = "success";
                }
                else
                {
                    // TempData["ToastMessage"] = $"Não conseguimos apagar seu contato, tente novamente";
                    // TempData["ToastType"] = "error";
                }

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                // TempData["ToastMessage"] = $"Não conseguimos deletar seu contato, tente novamente, detalhe do erro: {ex.Message}";
                // TempData["ToastType"] = "error";

                return RedirectToAction("Index");
            }
        }


    }
}
