   M S B A M L   `   `   `  ����R  NNetworkProgramming_HW_3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:NetworkProgramming_HW_3.View.TcpChatView(NetworkProgramming_HW_3.View.TcpChatView  5      7    1NetworkProgramming_HW_3.View.TcpChatView.ChatView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:NetworkProgramming_HW_3.View.TcpChatView     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      6!   �� 5      6!   �� 5      $
��0.3* �6   6.   �� 5      $
��0.3* �6   6.    � RowDefinitions 5   
   �� 5      $
��0.1* �6   6,   �� 5      6   �� 5      $
��0.2* �6   6,   .+�5   
   �� $��0��6   $��0��6   $��Center=�6-   $��Center=�6H   $��	User list��6e   6{   �� 5   
   $��0��6   $��1��6   $��Center=�6-   $��Center=�6H   $��Message��6e   6y   �� 5   
   -   5         ��Name$ onlineUserList��5   R   $��5,5,5,5q�6   $��1��6$   $��0��61   $��2��6A   ��6j   �� *
UserOnline+6�   �� 5   
   -   5        $ messageHistoyList��5   U   $��5,5,5,5q�6   $��1��6$   $��1��61   $��2��6A   ��6p   �� *
MsgHistory+6�   �� 5   
   -   5         ��Name$ userMsgTextBox��5   @   $��5,5,5,5q�6   $��2��6#   $��1��60   ��6X   �� *	UserMsg+6s   �� 5   
   -   5         ��Name$ sendMessage��5   ?   $��5,5,5,5q�6   $��2��6"   $��2��6/   $
��Send��6T   6�   5      5       