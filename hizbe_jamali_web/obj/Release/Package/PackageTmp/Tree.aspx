<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Tree.aspx.vb" Inherits="Hizbe_Jamali_Web.Tree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
                     <h1 style="background-color: #000080; color: #FFFFFF">
                    Syedna Mohammed Burhanuddin (RA) Family Tree
                </h1>
            </div>
           

       <p>
        <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" ShowCheckBoxes="None">
        <Nodes>
      <asp:TreeNode Text="Syedna Mohammed Burhanuddin RA & Amatullah Aai Saheba">
           
            <asp:TreeNode Text="1) Shz Sakina Ben Saheba & Jiwanji Bhai Saheb">
                <asp:TreeNode Text="Umme Salama Ben Saheba & Saifuddin Bhai Saheb" Expanded="false">
                    <asp:TreeNode Text="Mohammed Bhai Saheb">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Abdeali Bhai Saheb">
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Habiba Ben Saheba & Naeem Bhai Saheb" Expanded="false">
                    <asp:TreeNode Text="Umme Kulsum Ben Saheba">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Hatim Bhai Saheb">
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Zahra Ben Saheba & Mustafa Bhai Saheb" Expanded="false">
                    <asp:TreeNode Text="Hasan Bhai Saheb">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Badat Burhaniyaah Bhai Saheb">
                    </asp:TreeNode>
                </asp:TreeNode>
            </asp:TreeNode>

            <asp:TreeNode Text="2) Shz Batul ben Saheba & Yunus Bhai Saheb">
              <asp:TreeNode Text="Mehlam Bhai Saheb & Na'amaa Ben Saheba" Expanded="false">
                    <asp:TreeNode Text="Yahya Bhai Saheb">
                    </asp:TreeNode>
               </asp:TreeNode>
                <asp:TreeNode Text="Abde Manaf Bhai Saheb & Fatema Sugra Ben Saheba" Expanded="false">
                </asp:TreeNode>
                <asp:TreeNode Text="Arwa Ben Saheba & Al Azhar Bhai Saheb" Expanded="false">
                    <asp:TreeNode Text="Aliasgar Bhai Saheb">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Huzaifa Bhai Saheb">
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Umaimaah Ben Saheba & Zainul Aabedin Bhai Saheb" Expanded="false">
                    <asp:TreeNode Text="Maryam Ben Saheba">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Abbas Bhai Saheb">
                    </asp:TreeNode>
                </asp:TreeNode>
            </asp:TreeNode>

             <asp:TreeNode Text="3) Shz Qaid Johar Bhai Saheb Izzuddin & Samina Ben Saheba">
             <asp:TreeNode Text="Ibrahim Bhai Saheb & Fatema Ben Saheba" Expanded="false">
                    <asp:TreeNode Text="Nisreen Ben Saheba">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Khadija Ben Saheba">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Murtaza Bhai Saheb">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Husain Bhai Saheb">
                    </asp:TreeNode>
               </asp:TreeNode>
                <asp:TreeNode Text="Aliasgar Bhai Saheb & Batul Ben Saheba" Expanded="false">
                 <asp:TreeNode Text="Rabab Ben Saheba">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Abdul Qader Bhai Saheb">
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Tasneem Ben Saheba & Sadiqul Edizahabi Bhai Saheb" Expanded="false">
                   <asp:TreeNode Text="Fatema Ben Saheba">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Amatullah Ben Saheba">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Hashim Bhai Saheb">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Ajab Ben Saheba">
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Zainab Ben Saheba & Qusai Bhai Saheb" Expanded="false">
                        
                </asp:TreeNode>
                <asp:TreeNode Text="Taher Bhai Saheb & Zainab Ben Saheba" Expanded="false">
                    
               </asp:TreeNode>
            </asp:TreeNode>

             <asp:TreeNode Text="4) Shz Husaina Ben Saheba & Dr Moiz Bhai Saheb">
              <asp:TreeNode Text="Abdul Qader Bhai Saheb & Umme Haani Ben Saheba" Expanded="false">
                    <asp:TreeNode Text="Shere Banu Ben Saheba">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Insiyaah Ben Saheba">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Behlaah Bhai Saheb">
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Al Iqyaan Bhai Saheb & Nisreen Ben Saheba" Expanded="false">
                
                </asp:TreeNode>
                <asp:TreeNode Text="Ummul Kiraam Ben Saheba & Kinana Bhai Saheb" Expanded="false">
                    <asp:TreeNode Text="Husaina Ben Saheba">
                    </asp:TreeNode>
                   <asp:TreeNode Text="Khadija Ben Saheba">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Ruqaiyyah Ben Saheba">
                    </asp:TreeNode>
                   <asp:TreeNode Text="Alefiyah Ben Saheba">
                    </asp:TreeNode>
                     <asp:TreeNode Text="Yusuf Bhai Saheb">
                    </asp:TreeNode>
                     <asp:TreeNode Text="Hasan Bhai Saheb">
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Fatema Ben Saheba & Moiz Bhai Saheb" Expanded="false">
                   <asp:TreeNode Text="Hasan Bhai Saheb">
                    </asp:TreeNode>
                     <asp:TreeNode Text="Durratus Sharaf Ben Saheba">
                    </asp:TreeNode>
                  </asp:TreeNode>
            </asp:TreeNode>

             <asp:TreeNode Text="5) Syedna Mufaddal Moula Saifuddin (TUS) & Johratus Sharaf Aai Saheba">
             <asp:TreeNode Text="Shz Jaafarus Sadiq Bhai Saheb & Zainab Ben Saheba" Expanded="false">
                   
               </asp:TreeNode>
                <asp:TreeNode Text="Shz Taha Bhai Saheb & Arwa Ben Saheba" Expanded="false">
                 <asp:TreeNode Text="Shz Sakina Ben Saheba">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Mohammed Bhai Saheb">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Mustafa Bhai Saheb">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Murtaza Bhai Saheb">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Taher Bhai Saheb">
                    </asp:TreeNode>

                </asp:TreeNode>
                <asp:TreeNode Text="Shz Husain Bhai Saheb & Naqiyah Ben Saheba" Expanded="false">
                   <asp:TreeNode Text="Zahra Ben Saheba">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Qaid Johar Ben Saheba">
                    </asp:TreeNode>
                    
                </asp:TreeNode>
                <asp:TreeNode Text="Shz Umme Haani Ben Saheba & Abdul Qader Bhai Saheb" Expanded="false">
                   <asp:TreeNode Text="Behlaah Bhai Saheb">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Shere Banu Ben Saheba">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Insiyaah Ben Saheba">
                    </asp:TreeNode>
               
                </asp:TreeNode>
                 <asp:TreeNode Text="Shz Ruaqaiyyah Ben Saheba & Al Aqmar Bhai Saheb" Expanded="false">
                    
               </asp:TreeNode>
            </asp:TreeNode>

             <asp:TreeNode Text="6) Shz Malikul Ashtar Bhai Saheb Shujauddin & Tasneem Ben Saheba">
              <asp:TreeNode Text="Rabab Ben Saheba & Shabbir Bhai Saheb" Expanded="false">
                    <asp:TreeNode Text="Moiz Bhai Saheb">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Fatema Bhai Saheb">
                    </asp:TreeNode>
                </asp:TreeNode>
                 <asp:TreeNode Text="Naqiyaah Ben Saheba & Husain Bhai Saheb" Expanded="false">
                    <asp:TreeNode Text="Qaid Johar Bhai Saheb">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Zahra Bhai Saheb">
                    </asp:TreeNode>
                </asp:TreeNode>
              <asp:TreeNode Text="Taha Bhai Saheb" Expanded="false">
                                  </asp:TreeNode>
                <asp:TreeNode Text="Abdeali Bhai Saheb" Expanded="false">
                </asp:TreeNode>
                </asp:TreeNode>

             <asp:TreeNode Text="7) Shz Huzaifa Bhai Saheb Mohyuddin & Nafisa Ben Saheba">
               <asp:TreeNode Text="Taikhum Bhai Saheb & Jamila Ben Saheba" Expanded="false">
                    <asp:TreeNode Text="Mohammed Bhai Saheb">
                    </asp:TreeNode>
                    
                </asp:TreeNode>
                 <asp:TreeNode Text="Ajab Ben Saheba & Abduttayyeb Bhai Saheb" Expanded="false">
                    <asp:TreeNode Text="Jumama Ben Saheba">
                    </asp:TreeNode>
                   
                </asp:TreeNode>
             <asp:TreeNode Text="Umaima Ben Saheba & Shabbir Bhai Saheb" Expanded="false">
             <asp:TreeNode Text="Hawwa Bhai Saheb">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Taher Bhai Saheb">
                    </asp:TreeNode>
                    
                </asp:TreeNode>
            </asp:TreeNode>

             <asp:TreeNode Text="8) Shz Idris Bhai Saheb Badruddin & Johratul Majd Ben Saheb">
              <asp:TreeNode Text="Al Anwar Bhai Saheb & Maryam Ben Saheba" Expanded="false">
                   
                </asp:TreeNode>
                 <asp:TreeNode Text="Hawra Ben Saheba & Shabbir Bhai Saheb" Expanded="false">
                    <asp:TreeNode Text="Zahra Ben Saheba">
                    </asp:TreeNode>
                    <asp:TreeNode Text="Shireen Bhai Saheb">
                    </asp:TreeNode>
                </asp:TreeNode>
             
            </asp:TreeNode>
             
             <asp:TreeNode Text="9) Shz Qusai Bhai Saheb Vajihuddin & Tasneem Ben Saheba ">
               <asp:TreeNode Text="Abudttaiyyeb Bhai Saheb & Ajab Ben Saheba" Expanded="false">
                    <asp:TreeNode Text="Jumana Ben Saheba">
                    </asp:TreeNode>
               </asp:TreeNode>
               <asp:TreeNode Text="Al Aqmar Bhai Saheb & Ruqaiyyah Ben Saheba" Expanded="false">
               </asp:TreeNode>
               <asp:TreeNode Text="Adam Bhai Saheb" Expanded="false">
               </asp:TreeNode>
               <asp:TreeNode Text="Fatema Sugra Ben Saheba & Abde Manaf Bhai Saheb" Expanded="false">
               </asp:TreeNode>
               <asp:TreeNode Text="Zainab Sugra Ben Saheba & Aliasgar Bhai Saheb" Expanded="false">
                    <asp:TreeNode Text="Taher Bhai Saheb">
                    </asp:TreeNode>
               </asp:TreeNode>
            </asp:TreeNode>

            <asp:TreeNode Text="9) Shz Qusai Bhai Saheb Vajihuddin & Badat Taiyebaah Ben Saheba ">
            <asp:TreeNode Text="Qutubkhan Bhai Saheb">
                   
               </asp:TreeNode>
                <asp:TreeNode Text="Zahra Ben Saheba">
               </asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="10) Shz Ammar Bhai Saheb Jamaluddin & Zahabiya Ben Saheba ">
            <asp:TreeNode Text="Zahra Ben Saheba & Hasan Bhai Saheb">
                   
               </asp:TreeNode>
               <asp:TreeNode Text="Aliasgar Bhai Saheb">
               </asp:TreeNode>
               <asp:TreeNode Text="Shabbir Bhai Saheb">
               </asp:TreeNode>
              
            </asp:TreeNode>
        </asp:TreeNode>
        </Nodes>
        </asp:TreeView>
         </p>

   
   
    </form>
</body>
</html>


