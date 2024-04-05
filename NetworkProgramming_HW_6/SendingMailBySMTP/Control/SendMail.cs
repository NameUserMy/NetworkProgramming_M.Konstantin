using Microsoft.Win32;
using SendingMailBySMTP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SendingMailBySMTP.Control
{
    internal class SendMail
    {

        private MailMessage _mailMessage;
        private MessageModel _message;
        private SmtpClient _smtp;

        public async void SendMailAsync()
        {
            await Task.Run(CreateMessage);
            try
            {
                await Task.Run(() => _smtp.Send(_mailMessage));
                MessageBox.Show("Mail is send");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }
        private void CreateMessage() {
            try
            {
                _mailMessage.To.Add(new MailAddress(_message.SendTo));
                _mailMessage.From = new MailAddress(_message.SenFrom);
                _mailMessage.Subject = _message.Subject;
                _mailMessage.Body = _message.Body;
                _mailMessage.Attachments.Add(new Attachment(_message.File));
                _smtp.Port = Convert.ToInt32(_message.Port);
                _smtp.Host = _message.Loggin;
                _smtp.Credentials = new NetworkCredential(_message.SenFrom, _message.Pass);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           
        }

        public void GetFile() {

            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "File"; 
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                _message.File= dialog.FileName;
            }


        }
        public SendMail(MessageModel messageModel) {

            _message = messageModel;
            _smtp = new SmtpClient();
            _mailMessage = new MailMessage();
            _mailMessage.SubjectEncoding = Encoding.UTF8;
            _mailMessage.BodyEncoding = Encoding.UTF8;
            _smtp.EnableSsl = true; 
                                   

        }
    }
}
