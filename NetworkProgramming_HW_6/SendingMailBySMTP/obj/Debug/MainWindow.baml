   M S B A M L   `   `   `  ����L  HSendingMailBySMTP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SendingMailBySMTPSendingMailBySMTP  5   	   A%clr-namespace:SendingMailBySMTP.ModelSendingMailBySMTP.Model  5   	   "    SendingMailBySMTP.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SendingMailBySMTP     5   	   4Vm%clr-namespace:SendingMailBySMTP.Model     5   	     � Title$  SMTP Client��5	   	   $	��350��6   $	��350��6*    � WindowStartupLocation$ CenterScreen=�66    � DataContext 5
      *  $SendingMailBySMTP.Model.MessageModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.3* �6   6,   �� 5      $
��0.3* �6   6-   �� 5      $
��0.3* �6   6,   �� 5      $
��0.3* �6   6,   �� 5      $��1* �6   6*   �� 5      $
��1.2* �6   6,   �� 5      $
��0.5* �6   6,    � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   6.   �� 5      6!   .+�5   
   �� $��0��6   $��0��6   $��
To send : ��6-   6D   �� 5   
   $��1��6   $��0��6   $��From send : ��6-   6F   �� 5   
   $��2��6   $��0��6   $��Theme : ��6-   6B   �� 5   
   $��3��6   $��0��6   $��2��6-   $��Center=�6A   $��Message��6^   6r   �� 5    
   -   5         ��Name$ toSend��5    @   $��3,3,3,3q�6   $��0��6#   $��1��60   ��6P   �� *SendTo+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5!   
   -   5        $ fromSend��5!   @   $��3,3,3,3q�6   $��1��6#   $��1��60   ��6R   �� *	SenFrom+$ PropertyChanged=�6�   �� 5"   
   -   5        $ discription��5"   @   $��3,3,3,3q�6   $��2��6#   $��1��60   ��6U   �� *	Subject+$ PropertyChanged=�6�   �� 5#   
   -   5        $ messageText��5#   T   $��3,3,3,3q�6   $��4��6#   $��0��60   $��2��6@   ��6i   �� *Body+$ PropertyChanged=�6�   � 5%   
   $��5��6   $��0��6   $��2��6,    5&      �� 5'      6"   �� 5(      6"   �� 5)      6"   �� 5*      6"    5,      �� 5-      $
��0.6* �6#   62   �� 5.      6%   �� 5/      6%   .+�51      �� $��0��6   $��0��6!   $��Port : ��61   6E   �� 52      $��1��6   $��0��6!   $��	Server : ��61   6G   �� 53      $��2��6   $��0��6!   $��Password : ��61   6I   �� 54      -   5        $ portTextBox��54   D   $��3,3,3,3q�6   $��0��6'   $��1��64   ��6Y   �� *Port+$ PropertyChanged=�6�   �� 55      -   5        $ serverTextbox��55   D   $��3,3,3,3q�6   $��1��6'   $��1��64   ��6[   �� *Loggin+$ PropertyChanged=�6�   �� 56      -   5        $ passTextBox��56   D   $��3,3,3,3q�6   $��2��6'   $��1��64   ��6Z   �� *Pass+$ PropertyChanged=�6�   �� 57      -   5         ��Name$ sendfile��57   D   $��2��6   $��1��6%   $��30,2,2,5q�62   $��	Send file��6W   6�   �� 58      -	   5        $ sendMail��58   D   $��2��6   $��2��6%   $��30,2,2,5q�62   $��	Send Mail��6V   6�   59      5;      5<      