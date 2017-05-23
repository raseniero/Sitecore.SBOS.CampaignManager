Demo

Assumption:
1. If you want to follow the demo, please install Habitat sample site.

Steps:

1. Login to the Sitecore Client using your prefered browser.

![image]()

2. In Sitecore Launchpad click on **Desktop**.

![image]()

3. In Sitecore Desktop Click **Sitecore Icon** and then select Content Editor

![image]()

4. In Sitecore Content tree in the left panel click on **sitecore/content/Habitat/Global/Teasers**. 
5. Since we are using Sitecore Habitat and Campaign Manager only work with external link we need to access Global where Teasers folder is located. 

![image]()

6. 	Inside Teasers folder are Teaser component which is using external link in their content.
	Click About Habitat(component) in the Content panel right below **Quick Info** click **Content** and scroll down look for **Teaser Link** and on Teaser Link kindly click **Insert external link**.

![image]()

![image]()

7. 	Inside **Insert External Link** dialog in the bottom part you can see we added **Trigger Campaign:** using a CheckBox and also **Campaign:** using ComboBox.
8. 	Trigger Campaign: If you Check ✔ the checkBox it will trigger **True** and if not it will trigger **False**.
   	If True you want to trigger the Campaign; If False you don't want to trigger the Campaign.
9. 	Campaign: The comboBox create a list of Campaign and it also uses a javascript that allows the user to **AutoComplete**.
10. If you click **Insert** it will create a **OnClick Event** from About Habitat Link.
11. In this Image example I triggered the Campaign  by checking ✔ the CheckBox and Select a Campaign name **Social Marketer** and click **Insert**.

![image]()

12. After clicking **Insert** in Insert External Link. Click **Save** to save the changes. And Click Publish to publish the changes you made from the **Web Database**.

![image]()

13. After clicking Publish button select **Publish Item** to publish the item you changes and the Publish dialog will pop out.

![image]()

14. In the **Publishing section** select **Smart publish** and check ✔ the Publish subitems, Publish related items, and then click **Publish** Button and click
	Yes.

![image]()

15. After Publishing you will see a dialog box that indicates the item you publish and since I just update 1 Item only you can double check it.

![image]()

16. After Successfully publishing your changes. To to your Instance example http://Sitecore101/ and in this Demo we are using Sitecore Habitat. You can locate **
	About Habitat** below Sitecore Habitat Home Page in the footer section.

![image]()
![image]()

17. To check if the Teaser Link Button added **OnClick** in the html structure please use developer tool in Google Chrome or Firefox and use shortcut key “F12” in
	the “Elements” tab you can see the html structures. Use inspect button to inspect the About Habitat Link which has the tag name **Example available on Github**.

![image]()

18.Then Let’s Start Testing. Just Click the About Habitat Link which is **Example available on Github** and the Campaign dialog will pop out just click **OK**.

![image]()

19. To Check if the Campaign is really Triggered you can look at the Sitecore Habitat Information Bar in the Right panel of the Site.

![image]()

20. After clicking the Information Bar just click **Refresh** and Click **Referral**.

![image]()

21. You can check the Triggered campaigns in Referral. Since we triggered **Social Marketer** in the Sitecore Client it will list here in the Referral.

![image]()

22. End
