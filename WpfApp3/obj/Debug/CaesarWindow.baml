   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	       WpfApp3.CaesarWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	     � Title$  Caesar Cipher��5   	   $	��350��6   $	��525��6,   .��5	      � $��0,0,2,-4q�6   .+�5
   
   �� -   5         ��Name$ passwordText��5
      $
��Left=�6(   $��26��6C   $��	87,58,0,0q�6O    �� TextWrapping$
 Wrap=�6b   $��TextBox��6v   $	��Top=�6�   $	��128��6�   �� 5   
   -   5        $ keyText��5      $
��Left=�6#   $��26��6>   $��
259,58,0,0q�6J   $
 Wrap=�6^   $��TextBox��6r   $	��Top=�6�   $	��137��6�   �� 5   
   $��Enter your numerical key��6   $
��Left=�63   $��26��6N   $��
259,27,0,0q�6Z   $	��Top=�6n   $	��155��6�   �� 5   
   -   5        $��Encrypt��5      $
��Left=�6#   $��58��6>   $��
68,132,0,0q�6J   $	��Top=�6^   $	��161��6v   6�   �� 5   
   -   5        $��Decrypt��5      $
��Left=�6#   $��58��6>   $��259,132,0,0q�6J   $	��Top=�6_   $	��156��6w   6�   �� 5   
   $��Enter your text��6   $
��Left=�6*   $��26��6E   $��	87,27,0,0q�6Q   $	��Top=�6d   $	��155��6|   �� 5   
   -   5        $ 
resultText��5      $
��Left=�6&   $��44��6A   $��
68,242,0,0q�6M   $
 Wrap=�6a   $��TextBox��6u   $	��Top=�6�   $	��385��6�   �� 5   
   $��The result is:��6   $
��Left=�6)   $��26��6D   $��
68,211,0,0q�6P   $	��Top=�6d   $	��279��6|   5      5      