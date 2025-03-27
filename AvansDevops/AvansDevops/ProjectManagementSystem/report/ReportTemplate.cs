using System.Text;

namespace AvansDevops.ProjectManagementSystem.report {
    public class ReportTemplate {
        public string header { get; set; }
        public string footer { get; set; }

        public ReportTemplate(string header, string footer) {
            this.header = header;
            this.footer = footer;
        }           
    }
}
