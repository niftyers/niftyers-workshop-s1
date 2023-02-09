using Microsoft.AspNetCore.Mvc; 


namespace Niftyers {
    
    [ApiController]
    [Route("[controller]")]

        public class AnnouncementsController : ControllerBase {

             public static List<Announcement> Announcements = new List<Announcement>();

             public IActionResult AnnouncemenstList() {

               var result = new ResponseAnnouncementList();
               result.Success = true;
               result.Message = string.Format("{0} records found", Announcements.Count);
               result.Data = Announcements;

                return Ok(result);
             }
            [HttpPost("Create")]
             public IActionResult Create(PayloadAnnouncement payload) {
                  var a = new Announcement();

                  a.ID = Guid.NewGuid().ToString();
                  a.Tittle = payload.Tittle;
                  a.Description = payload.Description;
                  a.Image = payload.Image;
                  a.PostDate = payload.PostDate;
                  a.CreateDate = payload.CreateDate;
                  a.Status = payload.Status;
                  a.Clickable =  payload.Clickable;

                  Announcements.Add(a);

                  var result = new ResponseAnnouncement();
                  result.Success = true;
                  result.Message = "Created a new Announcement";
                  result.Data = a;

                return Ok(result);
            }

            [HttpPost("Info")]
             public IActionResult Info(string ID) {
                
               var result = new ResponseAnnouncement();
               var a = Announcements.Find(a => a.ID == ID);

                if (a == null) {
                  result.Message = "No record found";
                  return Ok(result);
                }

               result.Success = true;
               result.Message = "Record found";
               result.Data = a;

                return Ok(result);
             }

            [HttpPost("Update")]
             public IActionResult Update(PayloadAnnouncement payload) {
               
               var result = new Response();

               if (payload.ID == null || payload.ID == "") {
                  result.Message = "Id is required";
                   return Ok(result);
               }

               var a = Announcements.Find(a => a.ID == payload.ID);

               if (a == null) {
                    result.Message = "No record found";
                   return Ok(result);
               }

               a.Tittle = payload.Tittle;             
               a.PostDate = payload.PostDate;    
               a.Clickable = payload.Clickable;
               a.Description = payload.Description;   
               a.CreateDate = payload.CreateDate;
               a.Image = payload.Image;               
               a.Status = payload.Status;
              
               result.Success = true;
               result.Message = "Sucessfully updated";

               return Ok(result);
             }

            [HttpPost("Delete")]
             public IActionResult Delete(string ID) {

               var a = Announcements.Find(a => a.ID == ID);

               if (a == null) return Ok("No record found");

               Announcements.Remove(a);

               var result = new Response();
               result.Success = true;
               result.Message = "Item Succesfully Delete";

               return Ok(result);
             }
        }
}