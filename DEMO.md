Demo

Assumption:
1. If you want to follow the demo, please install Habitat sample site.

Steps:

1. Login to the Sitecore Client using your prefered browser.

![login1](https://cloud.githubusercontent.com/assets/2329372/26417963/73b3471c-406f-11e7-892d-dbda223c7f42.png)

2. In Sitecore Launchpad click on **Desktop**.

![launchpad2](https://cloud.githubusercontent.com/assets/2329372/26417964/73b56592-406f-11e7-8b71-86e78c88fec2.png)

3. In Sitecore Desktop Click **Sitecore Icon** and then select Content Editor

![desktop3](https://cloud.githubusercontent.com/assets/2329372/26417962/738315c4-406f-11e7-9fe4-2de7d5a27b38.png)

4. In Sitecore Content tree in the left panel click on **sitecore/content/Habitat/Global/Teasers**. 

5. Since we are using Sitecore Habitat and Campaign Manager only work with external link we need to access Global where Teasers folder is located. 

![contenteditor4](https://cloud.githubusercontent.com/assets/2329372/26417961/7375ae8e-406f-11e7-85d7-8b48b1e37955.png)

6. Inside Teasers folder are Teaser component which is using external link in their content. Click About Habitat(component) in the Content panel right below **Quick Info** click **Content** and scroll down look for **Teaser Link** and on Teaser Link kindly click **Insert external link**.

![abouthabitat5](https://cloud.githubusercontent.com/assets/2329372/26417960/735bd5fe-406f-11e7-9c07-77f27e06bd77.png)

![externallink6](https://cloud.githubusercontent.com/assets/2329372/26417958/734fed2a-406f-11e7-9668-76777cd27fe5.png)

7. Inside **Insert External Link** dialog in the bottom part you can see we added **Trigger Campaign:** using a CheckBox and also **Campaign:** using ComboBox.

8. Trigger Campaign: If you Check ✔ the checkBox it will trigger **True** and if not it will trigger **False**. If True you want to trigger the Campaign; If False you don't want to trigger the Campaign.

9. Campaign: The comboBox create a list of Campaign and it also uses a javascript that allows the user to **AutoComplete**.

10. If you click **Insert** it will create a **OnClick Event** from About Habitat Link.

11. In this Image example I triggered the Campaign  by checking ✔ the CheckBox and Select a Campaign name **Social Marketer** and click **Insert**.

![externallink7](https://cloud.githubusercontent.com/assets/2329372/26417957/734d7b30-406f-11e7-98c8-faa498cda0e1.png)

12. After clicking **Insert** in Insert External Link. Click **Save** to save the changes. And Click Publish to publish the changes you made from the **Web Database**.

![about8](https://cloud.githubusercontent.com/assets/2329372/26417956/734b6fca-406f-11e7-86b9-29cb62209140.png)

13. After clicking Publish button select **Publish Item** to publish the item you changes and the Publish dialog will pop out.

![publishitem8](https://cloud.githubusercontent.com/assets/2329372/26417953/731c1fea-406f-11e7-885e-0cc2517af808.png)

14. In the **Publishing section** select **Smart publish** and check ✔ the Publish subitems, Publish related items, and then click **Publish** Button and click **Yes**.

![publish9](https://cloud.githubusercontent.com/assets/2329372/26417955/731d9e6a-406f-11e7-8325-1b873eec8b73.png)

15. After Publishing you will see a dialog box that indicates the item you publish and since I just update 1 Item only you can double check it.

![close10](https://cloud.githubusercontent.com/assets/2329372/26417952/730333b8-406f-11e7-889d-48bfbe131292.png)

16. After Successfully publishing your changes. To to your Instance example http://Sitecore101/ and in this Demo we are using Sitecore Habitat. You can locate **About Habitat** below Sitecore Habitat Home Page in the footer section.

![simplicity11](https://cloud.githubusercontent.com/assets/2329372/26417951/72fe5af0-406f-11e7-86ef-9553bdf6e345.png)

![simplicity12](https://cloud.githubusercontent.com/assets/2329372/26417950/72f1cbb4-406f-11e7-9bd7-3c5c0b89af8a.png)

17. To check if the Teaser Link Button added **OnClick** in the html structure please use developer tool in Google Chrome or Firefox and use shortcut key “F12” in the “Elements” tab you can see the html structures. Use inspect button to inspect the About Habitat Link which has the tag name **Example available on Github**.

![devtool13](https://cloud.githubusercontent.com/assets/2329372/26417946/72a9320a-406f-11e7-9e68-3119f18b320a.png)

18. Then Let’s Start Testing. Just Click the About Habitat Link which is **Example available on Github** and the Campaign dialog will pop out just click **OK**.

![alert14](https://cloud.githubusercontent.com/assets/2329372/26417947/72ad87f6-406f-11e7-9395-927608d3d56b.png)

19. To Check if the Campaign is really Triggered you can look at the Sitecore Habitat Information Bar in the Right panel of the Site.

![i15](https://cloud.githubusercontent.com/assets/2329372/26417949/72b7b6f4-406f-11e7-9bb8-ae61cbfafe68.png)

20. After clicking the Information Bar just click **Refresh** and Click **Referral**.

![referrer16](https://cloud.githubusercontent.com/assets/2329372/26417948/72b744a8-406f-11e7-8091-1add4f0c31f1.png)

21. You can check the Triggered campaigns in Referral. Since we triggered **Social Marketer** in the Sitecore Client it will list here in the Referral.

![refresh17](https://cloud.githubusercontent.com/assets/2329372/26417945/72a3178a-406f-11e7-98dc-bd1274c421d4.png)

22. End
