using CleaningRecords.DAL;
using CleaningRecords.Global;
using CleaningRecords.Moduli;
using Microsoft.EntityFrameworkCore;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace CleaningRecords.PDF
{
    public class GeneratePDF
    {
        PodaciContext db;
        int CleanerId;

        public void Create(int month, int year, int? _CleanerId, PodaciContext _db)
        {

            if (_CleanerId == null || _CleanerId == 0)
            {
                MessageBox.Show("Cleaner not selected!");
                return;
            }
            CleanerId = (int)_CleanerId;
            db = _db;

            var cleaner = db.Cleaners.FirstOrDefault(x => x.Id == CleanerId);
            if (cleaner == null)
                return;
            // Create a temporary file
            Directory.CreateDirectory("PDFs");
            string filename = String.Format($"{cleaner.Name}_{cleaner.Surname}_{month}_{year}_{Guid.NewGuid().ToString("D").ToUpper()}.pdf");
            var s_document = new PdfDocument();
            s_document.Info.Title = $"{cleaner.Name}_{cleaner.Surname} schedule";
            s_document.Info.Author = "Sven Ivic";
            s_document.Info.Subject = $"Calendar for {cleaner.Name}_{cleaner.Surname}";
            s_document.Info.Keywords = $"{cleaner.Name}_{cleaner.Surname} Calendar";

            // Create demonstration pages
            var page = s_document.AddPage();
            page.Orientation = PdfSharp.PageOrientation.Landscape;
            XGraphics gfx = XGraphics.FromPdfPage(page);



            DrawLine(gfx, month, year);

            // Save the s_document...
            s_document.Save("PDFs\\" + filename);
            // ...and start a viewer
            //Process.Start(filename);
            try
            {
                System.Diagnostics.Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", Directory.GetCurrentDirectory() + "\\PDFs");
            }
            catch (Exception ex)
            {
              
            }

        }


        private void DrawLine(XGraphics gfx, int month, int year)
        {
            var dayStart = Fun.getDay(new DateTime(year, month, 1));
            var dayEnd = Fun.getDay(new DateTime((month + 1) == 13 ? year + 1 : year, Math.Max(1,(month + 1) % 13), 1)) - 1;


            for (int i = 0; i < 7; i++)
                BeginHeader(gfx, i);
            for (int i = 0; i < 42; i++)
                BeginBox(gfx, i, dayStart, dayEnd, month, year);
            for (int i = 0; i < addresses.Count; i++)
                BeginAddress(gfx, i, addresses[i]);



            EndBox(gfx);
        }
        XGraphicsState state;
        XColor backColor = (XColors.Blue);
        XColor backColor2 = (XColors.Green);
        XPen borderPen = new XPen(XColors.Black, 2);


      
        public void BeginHeader(XGraphics gfx, int number)
        {

            XRect rect = new XRect(50, 30, 104, 20);

            rect.X += 104 * (number % 7);


            XLinearGradientBrush brush = new XLinearGradientBrush(new XPoint(1, 1), new XPoint(3, 3), this.backColor, this.backColor2);

            XBrush b = XBrushes.Transparent;
            gfx.DrawRectangle(borderPen, b, rect);


            XFont font = new XFont("Verdana", 12, XFontStyle.Regular);


            gfx.DrawString($"{ZP.days[number]}", font, XBrushes.Navy, rect, XStringFormats.TopCenter);



            state = gfx.Save();

        }
        List<string> addresses = new List<string>();
        private void BeginBox(XGraphics gfx, int number, int dayStart, int dayEnd, int month, int year)
        {


            XRect rect = new XRect(50, 50, 104, 60);

            rect.X += 104 * (number % 7);
            rect.Y += 60 * (number / 7);

            XLinearGradientBrush brush = new XLinearGradientBrush(new XPoint(1, 1), new XPoint(3, 3), this.backColor, this.backColor2);

            XBrush b = XBrushes.Transparent;
            gfx.DrawRectangle(borderPen, b, rect);



            var day = number - dayStart + 1;
            DateTime date = new DateTime();
            if (day < 1)
            {
                date = new DateTime(year, month, 1).AddDays(day - 1);
            }
            else if (day > dayEnd)
            {
                date = new DateTime(year, month, dayEnd).AddDays(day - dayEnd);
            }
            else
                date = new DateTime(year, month, day);

            var jobs = db.CleaningJobs.Include(x => x.Client).Where(x => x.CleanerId == CleanerId && x.Date.Date == date.Date)?.ToList();

            if (jobs != null && jobs.Count() == 1)
            {
                XFont font = new XFont("Verdana", 12, XFontStyle.Regular);
                gfx.DrawString($"{date.ToShortDateString()}", font, XBrushes.Navy, rect, XStringFormats.TopCenter);
                rect.Y += 14;
                gfx.DrawString($"{jobs[0].TimeStart.ToString("HH:mm")}-{jobs[0].TimeEnd.ToString("HH:mm")}", font, XBrushes.Navy, rect, XStringFormats.TopCenter);

                rect.Y += 14;
                gfx.DrawString($"{shorten(jobs[0].Client.Name, 15)}", font, XBrushes.Navy, rect, XStringFormats.TopCenter);
                rect.Y += 14;
                gfx.DrawString($"{shorten(jobs[0].Client.Surname, 15)}", font, XBrushes.Navy, rect, XStringFormats.TopCenter);
            }
            else if (jobs != null && jobs.Count() == 2)
            {

                XFont font = new XFont("Verdana", 10, XFontStyle.Regular);
                gfx.DrawString($"{date.ToShortDateString()}", font, XBrushes.Navy, rect, XStringFormats.TopCenter);
                rect.Y += 11;
                gfx.DrawString($"{jobs[0].TimeStart.ToString("HH:mm")}-{jobs[0].TimeEnd.ToString("HH:mm")}", font, XBrushes.Navy, rect, XStringFormats.TopCenter);

                rect.Y += 11;
                var name = shorten($"{jobs[0].Client.Name} {jobs[0].Client.Surname}", 19);
                gfx.DrawString(name, font, XBrushes.Navy, rect, XStringFormats.TopCenter);
                rect.Y += 11;
                gfx.DrawString($"{jobs[1].TimeStart.ToString("HH:mm")}-{jobs[1].TimeEnd.ToString("HH:mm")}", font, XBrushes.Navy, rect, XStringFormats.TopCenter);
                rect.Y += 11;
                name = shorten($"{jobs[1].Client.Name} {jobs[1].Client.Surname}", 19);
                gfx.DrawString(name, font, XBrushes.Navy, rect, XStringFormats.TopCenter);

            }
            else if (jobs != null && jobs.Count() > 2)
            {
                XFont font = new XFont("Verdana", 12, XFontStyle.Regular);
                gfx.DrawString($"{date.ToShortDateString()}", font, XBrushes.Navy, rect, XStringFormats.TopCenter);
                rect.Y += 14;
                gfx.DrawString($"Cant show more", font, XBrushes.Navy, rect, XStringFormats.TopCenter);
                rect.Y += 14;
                gfx.DrawString($"than 2 jobs!", font, XBrushes.Navy, rect, XStringFormats.TopCenter);
            }
            if (jobs != null)
                foreach (var job in jobs)
                {
                    if (job.LocationId == 0)
                        addresses.Add($"{job.Client.Name} {job.Client.Surname} - {job.Client.Address}");
                    if (job.LocationId == 1)
                        addresses.Add($"{job.Client.Name} {job.Client.Surname} - {job.Client.Address2}");
                    if (job.LocationId == 2)
                        addresses.Add($"{job.Client.Name} {job.Client.Surname} - {job.Client.Address3}");
                    if (job.LocationId == 3)
                        addresses.Add($"{job.Client.Name} {job.Client.Surname} - {job.Client.Address4}");
                }
            state = gfx.Save();

        }


        private string shorten(string s, int number)
        {
            if (s == null)
                return s;

            return s.Substring(0, Math.Min(s.Length, number));
        }
        private void BeginAddress(XGraphics gfx, int number, string address)
        {
            XRect rect = new XRect(40, 60 + 6 * 60, 104 * 3.5, 16);
            XFont font = new XFont("Verdana", 12, XFontStyle.Regular);

            rect.X += (104 * 3.5 + 20) * (number % 2);
            rect.Y += 17 * (number / 2);

            gfx.DrawString(address, font, XBrushes.Navy, rect, XStringFormats.TopCenter);

            state = gfx.Save();
        }


        private void EndBox(XGraphics gfx)
        {
            gfx.Restore(state);


        }


    }
}
