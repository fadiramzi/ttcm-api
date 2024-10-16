using ttcm_api.Contexts;
using ttcm_api.Interfaces;

namespace ttcm_api.Services
{
    public class ProgramsService : IProgramCRUD
    {
        private MainAppContext _appContext;
        public static List<ttcm_api.Models.Program> Programs = new List<ttcm_api.Models.Program>();
        public ProgramsService(MainAppContext mainAppContext)
        {
            _appContext = mainAppContext;
        }
        public Models.Program Update(int id, Models.Program newProgram)
        {
            //#1 go to the programs list and get the resource
            var oldProgam = Programs.FirstOrDefault(p => p.Id == id);
            if (oldProgam != null)
            {
                oldProgam.Title = newProgram.Title;
            }

            return oldProgam;
        }

        public bool Delete(int id)
        {
            // #1 go to the programs list and get the resource
            var program = Programs.FirstOrDefault(p => p.Id == id);
            if (program != null)
            {
                Programs.Remove(program);
                return true;
            }
            return false;
        }

        IEnumerable<Models.Program> IProgramCRUD.GetAll()
        {
            return _appContext.Programs.ToList() ;
        }

        Models.Program IProgramCRUD.Create(Models.Program p)
        {
            Programs.Add(p);

            return p;
        }

      

    }
}
