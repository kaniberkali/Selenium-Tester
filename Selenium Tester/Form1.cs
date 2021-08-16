using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.IO;

namespace Selenium_Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        OpenQA.Selenium.Chrome.ChromeDriver drv;
        private void Form1_Load(object sender, EventArgs e)
        {
            kodeditör.Enabled = true;
            kodeditör.Interval = 100;
            Thread th = new Thread(loading);th.Start();
        }
        private void loading()
        {
            if (Tür.SelectedIndex == -1)
                Tür.SelectedIndex = 0;
            if (Metotlar.SelectedIndex == -1)
                Metotlar.SelectedIndex = 1;
            if (site.Text == "")
                site.Text = "https://kodzamani.weebly.com";
            if (veri.Text == "")
                veri.Text = "//span[@id='wsite-title']";
            ChromeOptions option = new ChromeOptions();
            option.AddExcludedArgument("enable-automation");
            option.AddAdditionalCapability("useAutomationExtension", false);
            try
            {
                string dosya_yolu = @"settings.txt";
                FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                string yazi = sw.ReadLine();
                while (yazi != null)
                {
                    try
                    {
                        if (yazi.Split('|')[0] == "Delay")
                            kodeditör.Interval = Convert.ToInt32(yazi.Split('|')[1]);
                    }
                    catch { kodeditör.Interval = 100; }
                    try
                    {
                        if (yazi.Split('|')[0] == "Metot")
                            Metotlar.SelectedItem = yazi.Split('|')[1];
                    }
                    catch { Metotlar.SelectedIndex = 1; }
                    try
                    {
                        if (yazi.Split('|')[0] == "Tür")
                            Tür.SelectedItem = yazi.Split('|')[1];
                    }
                    catch { Tür.SelectedIndex = 0; }
                    try
                    {
                        if (yazi.Split('|')[0] == "Element")
                        {
                            if (yazi.Split('|')[1] == "true")
                                element.Checked = true;
                        }
                    }
                    catch { elements.Checked = true; }
                    try
                    {
                        if (yazi.Split('|')[0] == "Elements")
                        {
                            if (yazi.Split('|')[1] == "true")
                                elements.Checked = true;
                        }
                    }
                    catch { element.Checked = true; }
                    try
                    {
                        if (yazi.Split('|')[0] == "Site")
                            site.Text = yazi.Split('|')[1];
                    }
                    catch { site.Text = "https://kodzamani.weebly.com"; }
                    try
                    {
                        if (yazi.Split('|')[0] == "Veri")
                        {
                            metot_veri.Text = yazi.Split('|')[1];
                        }
                    }
                    catch { }
                    try
                    {
                        if (yazi.Split('|')[0] == "Visible")
                        {
                            if (yazi.Split('|')[1] == "true")
                                checkBox1.Checked = true;
                            else
                                checkBox1.Checked = false;
                        }
                    }
                    catch { checkBox1.Checked = true; }
                    try
                    {
                        if (yazi.Split('|')[0] == "Kopyala")
                        {
                            if (yazi.Split('|')[1] == "true")
                            {
                                kopyalamak.Checked = true;
                                if (yazi.Split('|')[1].Split('/')[1] == "element")
                                    radioButton1.Checked = true;
                                else
                                    radioButton2.Checked = true;
                                checkBox1.Checked = true;
                            }
                            else
                                kopyalamak.Checked = false;
                        }
                    }
                    catch { kopyalamak.Checked = false; }
                    try
                    {
                        if (yazi.Split('|')[0] == "Mobile")
                        {
                            if (yazi.Split('|')[1] == "true")
                            {
                                option.EnableMobileEmulation("iPhone X");
                                mobileemü = true;
                            }
                        }
                    }
                    catch { }
                    yazi = sw.ReadLine();
                }
                sw.Close();
                fs.Close();
            }
            catch
            {
                Tür.SelectedIndex = 0;
                Metotlar.SelectedIndex = 1;
            }
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            drv = new ChromeDriver(service, option);
            try
            {
                drv.Navigate().GoToUrl(site.Text);
            }
            catch { drv.Navigate().GoToUrl("https://kodzamani.weebly.com"); }
            drv.Manage().Window.FullScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;

        }

        private void kopyala_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(Kod.Text+ "//https://kodzamani.weebly.com");
            }
            catch { Clipboard.SetText("//https://kodzamani.weebly.com"); }
        }

        private void test_et_Click(object sender, EventArgs e)
        {
            if (Metotlar.Text == "Count")
            {
                try
                {
                    int metin = 0;
                    if (Tür.Text == "XPath")
                        metin = drv.FindElements(By.XPath(veri.Text)).Count;
                    if (Tür.Text == "Id")
                        metin = drv.FindElements(By.Id(veri.Text)).Count;
                    if (Tür.Text == "CssSelector")
                        metin = drv.FindElements(By.CssSelector(veri.Text)).Count;
                    if (Tür.Text == "Name")
                        metin = drv.FindElements(By.Name(veri.Text)).Count;
                    if (Tür.Text == "LinkText")
                        metin = drv.FindElements(By.LinkText(veri.Text)).Count;
                    if (Tür.Text == "ClassName")
                        metin = drv.FindElements(By.ClassName(veri.Text)).Count;
                    if (Tür.Text == "PartialLinkText")
                        metin = drv.FindElements(By.PartialLinkText(veri.Text)).Count;
                    if (Tür.Text == "TagName")
                        metin = drv.FindElements(By.TagName(veri.Text)).Count;
                    Console.Items.Add(DateTime.Now + ": Adet başarıyla çekildi : " + metin);
                }
                catch (Exception ex)
                {
                    Console.Items.Add(DateTime.Now + ": Adet çekilemedi. Hata :" + ex);
                }
            }
            if (element.Checked == true)
            {
                if (Metotlar.Text == "Text")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text=="XPath")
                        metin = drv.FindElement(By.XPath(veri.Text)).Text;
                        if (Tür.Text == "Id")
                            metin = drv.FindElement(By.Id(veri.Text)).Text;
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElement(By.CssSelector(veri.Text)).Text;
                        if (Tür.Text == "Name")
                            metin = drv.FindElement(By.Name(veri.Text)).Text;
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElement(By.LinkText(veri.Text)).Text;
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElement(By.ClassName(veri.Text)).Text;
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElement(By.PartialLinkText(veri.Text)).Text;
                        if (Tür.Text == "TagName")
                            metin = drv.FindElement(By.TagName(veri.Text)).Text;
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi : " + metin);
                    }
                    catch(Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "Click")
                {
                    try
                    {
                        if (Tür.Text == "XPath")
                           drv.FindElement(By.XPath(veri.Text)).Click();
                        if (Tür.Text == "Id")
                            drv.FindElement(By.Id(veri.Text)).Click();
                        if (Tür.Text == "CssSelector")
                            drv.FindElement(By.CssSelector(veri.Text)).Click();
                        if (Tür.Text == "Name")
                             drv.FindElement(By.Name(veri.Text)).Click();
                        if (Tür.Text == "LinkText")
                             drv.FindElement(By.LinkText(veri.Text)).Click();
                        if (Tür.Text == "ClassName")
                             drv.FindElement(By.ClassName(veri.Text)).Click();
                        if (Tür.Text == "PartialLinkText")
                           drv.FindElement(By.PartialLinkText(veri.Text)).Click();
                        if (Tür.Text == "TagName")
                             drv.FindElement(By.TagName(veri.Text)).Click();
                        Console.Items.Add(DateTime.Now + ": Butona başarıyla tıklatıldı.");
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Butona tıklatılamadı. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "SendKeys")
                {
                    try
                    {
                        if (Tür.Text == "XPath")
                            drv.FindElement(By.XPath(veri.Text)).SendKeys(metot_veri.Text);
                        if (Tür.Text == "Id")
                            drv.FindElement(By.Id(veri.Text)).SendKeys(metot_veri.Text);
                        if (Tür.Text == "CssSelector")
                            drv.FindElement(By.CssSelector(veri.Text)).SendKeys(metot_veri.Text);
                        if (Tür.Text == "Name")
                           drv.FindElement(By.Name(veri.Text)).SendKeys(metot_veri.Text);
                        if (Tür.Text == "LinkText")
                            drv.FindElement(By.LinkText(veri.Text)).SendKeys(metot_veri.Text);
                        if (Tür.Text == "ClassName")
                            drv.FindElement(By.ClassName(veri.Text)).SendKeys(metot_veri.Text);
                        if (Tür.Text == "PartialLinkText")
                            drv.FindElement(By.PartialLinkText(veri.Text)).SendKeys(metot_veri.Text);
                        if (Tür.Text == "TagName")
                           drv.FindElement(By.TagName(veri.Text)).SendKeys(metot_veri.Text);
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla yazıldı.");
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri yazılamadı. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "Clear")
                {
                    try
                    {
                        if (Tür.Text == "XPath")
                            drv.FindElement(By.XPath(veri.Text)).Clear();
                        if (Tür.Text == "Id")
                            drv.FindElement(By.Id(veri.Text)).Clear();
                        if (Tür.Text == "CssSelector")
                            drv.FindElement(By.CssSelector(veri.Text)).Clear();
                        if (Tür.Text == "Name")
                            drv.FindElement(By.Name(veri.Text)).Clear();
                        if (Tür.Text == "LinkText")
                            drv.FindElement(By.LinkText(veri.Text)).Clear();
                        if (Tür.Text == "ClassName")
                            drv.FindElement(By.ClassName(veri.Text)).Clear();
                        if (Tür.Text == "PartialLinkText")
                            drv.FindElement(By.PartialLinkText(veri.Text)).Clear();
                        if (Tür.Text == "TagName")
                            drv.FindElement(By.TagName(veri.Text)).Clear();
                        Console.Items.Add(DateTime.Now + ": Başarıyla temizlendi.");
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Temizlenemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "Displayed")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin= drv.FindElement(By.XPath(veri.Text)).Displayed.ToString();
                        if (Tür.Text == "Id")
                            metin = drv.FindElement(By.Id(veri.Text)).Displayed.ToString();
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElement(By.CssSelector(veri.Text)).Displayed.ToString();
                        if (Tür.Text == "Name")
                            metin = drv.FindElement(By.Name(veri.Text)).Displayed.ToString();
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElement(By.LinkText(veri.Text)).Displayed.ToString();
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElement(By.ClassName(veri.Text)).Displayed.ToString();
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElement(By.PartialLinkText(veri.Text)).Displayed.ToString();
                        if (Tür.Text == "TagName")
                            metin = drv.FindElement(By.TagName(veri.Text)).Displayed.ToString();
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi."+metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "Enabled")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElement(By.XPath(veri.Text)).Enabled.ToString();
                        if (Tür.Text == "Id")
                            metin = drv.FindElement(By.Id(veri.Text)).Enabled.ToString();
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElement(By.CssSelector(veri.Text)).Enabled.ToString();
                        if (Tür.Text == "Name")
                            metin = drv.FindElement(By.Name(veri.Text)).Enabled.ToString();
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElement(By.LinkText(veri.Text)).Enabled.ToString();
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElement(By.ClassName(veri.Text)).Enabled.ToString();
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElement(By.PartialLinkText(veri.Text)).Enabled.ToString();
                        if (Tür.Text == "TagName")
                            metin = drv.FindElement(By.TagName(veri.Text)).Enabled.ToString();
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi." + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "GetAttribute")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin= drv.FindElement(By.XPath(veri.Text)).GetAttribute(metot_veri.Text);
                        if (Tür.Text == "Id")
                            metin = drv.FindElement(By.Id(veri.Text)).GetAttribute(metot_veri.Text);
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElement(By.CssSelector(veri.Text)).GetAttribute(metot_veri.Text);
                        if (Tür.Text == "Name")
                            metin = drv.FindElement(By.Name(veri.Text)).GetAttribute(metot_veri.Text);
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElement(By.LinkText(veri.Text)).GetAttribute(metot_veri.Text);
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElement(By.ClassName(veri.Text)).GetAttribute(metot_veri.Text);
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElement(By.PartialLinkText(veri.Text)).GetAttribute(metot_veri.Text);
                        if (Tür.Text == "TagName")
                            drv.FindElement(By.TagName(veri.Text)).GetAttribute(metot_veri.Text);
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi : "+metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "GetCssValue")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElement(By.XPath(veri.Text)).GetCssValue(metot_veri.Text);
                        if (Tür.Text == "Id")
                            metin = drv.FindElement(By.Id(veri.Text)).GetCssValue(metot_veri.Text);
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElement(By.CssSelector(veri.Text)).GetCssValue(metot_veri.Text);
                        if (Tür.Text == "Name")
                            metin = drv.FindElement(By.Name(veri.Text)).GetCssValue(metot_veri.Text);
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElement(By.LinkText(veri.Text)).GetCssValue(metot_veri.Text);
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElement(By.ClassName(veri.Text)).GetCssValue(metot_veri.Text);
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElement(By.PartialLinkText(veri.Text)).GetCssValue(metot_veri.Text);
                        if (Tür.Text == "TagName")
                            metin = drv.FindElement(By.TagName(veri.Text)).GetCssValue(metot_veri.Text);
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi : "+metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "GetHashCode")
                {
                    try
                    {
                        int metin=0;
                        if (Tür.Text == "XPath")
                            metin = drv.FindElement(By.XPath(veri.Text)).GetHashCode();
                        if (Tür.Text == "Id")
                            metin = drv.FindElement(By.Id(veri.Text)).GetHashCode();
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElement(By.CssSelector(veri.Text)).GetHashCode();
                        if (Tür.Text == "Name")
                            metin = drv.FindElement(By.Name(veri.Text)).GetHashCode();
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElement(By.LinkText(veri.Text)).GetHashCode();
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElement(By.ClassName(veri.Text)).GetHashCode();
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElement(By.PartialLinkText(veri.Text)).GetHashCode();
                        if (Tür.Text == "TagName")
                            metin = drv.FindElement(By.TagName(veri.Text)).GetHashCode();
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi :"+metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "GetProperty")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElement(By.XPath(veri.Text)).GetProperty(metot_veri.Text);
                        if (Tür.Text == "Id")
                            metin = drv.FindElement(By.Id(veri.Text)).GetProperty(metot_veri.Text);
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElement(By.CssSelector(veri.Text)).GetProperty(metot_veri.Text);
                        if (Tür.Text == "Name")
                            metin = drv.FindElement(By.Name(veri.Text)).GetProperty(metot_veri.Text);
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElement(By.LinkText(veri.Text)).GetProperty(metot_veri.Text);
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElement(By.ClassName(veri.Text)).GetProperty(metot_veri.Text);
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElement(By.PartialLinkText(veri.Text)).GetProperty(metot_veri.Text);
                        if (Tür.Text == "TagName")
                            drv.FindElement(By.TagName(veri.Text)).GetAttribute(metot_veri.Text);
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi : " + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "Location")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElement(By.XPath(veri.Text)).Location.ToString();
                        if (Tür.Text == "Id")
                            metin = drv.FindElement(By.Id(veri.Text)).Location.ToString();
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElement(By.CssSelector(veri.Text)).Location.ToString();
                        if (Tür.Text == "Name")
                            metin = drv.FindElement(By.Name(veri.Text)).Location.ToString();
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElement(By.LinkText(veri.Text)).Location.ToString();
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElement(By.ClassName(veri.Text)).Location.ToString();
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElement(By.PartialLinkText(veri.Text)).Location.ToString();
                        if (Tür.Text == "TagName")
                            metin = drv.FindElement(By.TagName(veri.Text)).Location.ToString();
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi." + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                    
                }
                if (Metotlar.Text == "Selected")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElement(By.XPath(veri.Text)).Selected.ToString();
                        if (Tür.Text == "Id")
                            metin = drv.FindElement(By.Id(veri.Text)).Selected.ToString();
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElement(By.CssSelector(veri.Text)).Selected.ToString();
                        if (Tür.Text == "Name")
                            metin = drv.FindElement(By.Name(veri.Text)).Selected.ToString();
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElement(By.LinkText(veri.Text)).Selected.ToString();
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElement(By.ClassName(veri.Text)).Selected.ToString();
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElement(By.PartialLinkText(veri.Text)).Selected.ToString();
                        if (Tür.Text == "TagName")
                            metin = drv.FindElement(By.TagName(veri.Text)).Selected.ToString();
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi." + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "Size")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElement(By.XPath(veri.Text)).Size.ToString();
                        if (Tür.Text == "Id")
                            metin = drv.FindElement(By.Id(veri.Text)).Size.ToString();
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElement(By.CssSelector(veri.Text)).Size.ToString();
                        if (Tür.Text == "Name")
                            metin = drv.FindElement(By.Name(veri.Text)).Size.ToString();
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElement(By.LinkText(veri.Text)).Size.ToString();
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElement(By.ClassName(veri.Text)).Size.ToString();
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElement(By.PartialLinkText(veri.Text)).Size.ToString();
                        if (Tür.Text == "TagName")
                            metin = drv.FindElement(By.TagName(veri.Text)).Size.ToString();
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi." + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "Submit")
                {
                    try
                    {
                        if (Tür.Text == "XPath")
                            drv.FindElement(By.XPath(veri.Text)).Submit();
                        if (Tür.Text == "Id")
                            drv.FindElement(By.Id(veri.Text)).Submit();
                        if (Tür.Text == "CssSelector")
                            drv.FindElement(By.CssSelector(veri.Text)).Submit();
                        if (Tür.Text == "Name")
                            drv.FindElement(By.Name(veri.Text)).Submit();
                        if (Tür.Text == "LinkText")
                            drv.FindElement(By.LinkText(veri.Text)).Submit();
                        if (Tür.Text == "ClassName")
                            drv.FindElement(By.ClassName(veri.Text)).Submit();
                        if (Tür.Text == "PartialLinkText")
                            drv.FindElement(By.PartialLinkText(veri.Text)).Submit();
                        if (Tür.Text == "TagName")
                            drv.FindElement(By.TagName(veri.Text)).Submit();
                        Console.Items.Add(DateTime.Now + ": Butona başarıyla tıklatıldı.");
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Butona tıklatılamadı. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "TagName")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElement(By.XPath(veri.Text)).TagName;
                        if (Tür.Text == "Id")
                            metin = drv.FindElement(By.Id(veri.Text)).TagName;
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElement(By.CssSelector(veri.Text)).TagName;
                        if (Tür.Text == "Name")
                            metin = drv.FindElement(By.Name(veri.Text)).TagName;
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElement(By.LinkText(veri.Text)).TagName;
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElement(By.ClassName(veri.Text)).TagName;
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElement(By.PartialLinkText(veri.Text)).TagName;
                        if (Tür.Text == "TagName")
                            metin = drv.FindElement(By.TagName(veri.Text)).TagName;
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi : " + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "ToString")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElement(By.XPath(veri.Text)).ToString();
                        if (Tür.Text == "Id")
                            metin = drv.FindElement(By.Id(veri.Text)).ToString();
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElement(By.CssSelector(veri.Text)).ToString();
                        if (Tür.Text == "Name")
                            metin = drv.FindElement(By.Name(veri.Text)).ToString();
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElement(By.LinkText(veri.Text)).ToString();
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElement(By.ClassName(veri.Text)).ToString();
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElement(By.PartialLinkText(veri.Text)).ToString();
                        if (Tür.Text == "TagName")
                            metin = drv.FindElement(By.TagName(veri.Text)).ToString();
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi : " + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
            }
            else
            {
                if (Metotlar.Text == "Text")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].Text;
                        if (Tür.Text == "Id")
                            metin = drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].Text;
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].Text;
                        if (Tür.Text == "Name")
                            metin = drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].Text;
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].Text;
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].Text;
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].Text;
                        if (Tür.Text == "TagName")
                            metin = drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].Text;
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi : " + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "Click")
                {
                    try
                    {
                        if (Tür.Text == "XPath")
                            drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].Click();
                        if (Tür.Text == "Id")
                            drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].Click();
                        if (Tür.Text == "CssSelector")
                            drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].Click();
                        if (Tür.Text == "Name")
                            drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].Click();
                        if (Tür.Text == "LinkText")
                            drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].Click();
                        if (Tür.Text == "ClassName")
                            drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].Click();
                        if (Tür.Text == "PartialLinkText")
                            drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].Click();
                        if (Tür.Text == "TagName")
                            drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].Click();
                        Console.Items.Add(DateTime.Now + ": Butona başarıyla tıklatıldı.");
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Butona tıklatılamadı. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "SendKeys")
                {
                    try
                    {
                        if (Tür.Text == "XPath")
                            drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].SendKeys(metot_veri.Text);
                        if (Tür.Text == "Id")
                            drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].SendKeys(metot_veri.Text);
                        if (Tür.Text == "CssSelector")
                            drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].SendKeys(metot_veri.Text);
                        if (Tür.Text == "Name")
                            drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].SendKeys(metot_veri.Text);
                        if (Tür.Text == "LinkText")
                            drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].SendKeys(metot_veri.Text);
                        if (Tür.Text == "ClassName")
                            drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].SendKeys(metot_veri.Text);
                        if (Tür.Text == "PartialLinkText")
                            drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].SendKeys(metot_veri.Text);
                        if (Tür.Text == "TagName")
                            drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].SendKeys(metot_veri.Text);
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla yazıldı.");
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri yazılamadı. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "Clear")
                {
                    try
                    {
                        if (Tür.Text == "XPath")
                            drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].Clear();
                        if (Tür.Text == "Id")
                            drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].Clear();
                        if (Tür.Text == "CssSelector")
                            drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].Clear();
                        if (Tür.Text == "Name")
                            drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].Clear();
                        if (Tür.Text == "LinkText")
                            drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].Clear();
                        if (Tür.Text == "ClassName")
                            drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].Clear();
                        if (Tür.Text == "PartialLinkText")
                            drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].Clear();
                        if (Tür.Text == "TagName")
                            drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].Clear();
                        Console.Items.Add(DateTime.Now + ": Başarıyla temizlendi.");
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Temizlenemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "Displayed")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].Displayed.ToString();
                        if (Tür.Text == "Id")
                            metin = drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].Displayed.ToString();
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].Displayed.ToString();
                        if (Tür.Text == "Name")
                            metin = drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].Displayed.ToString();
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].Displayed.ToString();
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].Displayed.ToString();
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].Displayed.ToString();
                        if (Tür.Text == "TagName")
                            metin = drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].Displayed.ToString();
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi." + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "Enabled")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].Enabled.ToString();
                        if (Tür.Text == "Id")
                            metin = drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].Enabled.ToString();
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].Enabled.ToString();
                        if (Tür.Text == "Name")
                            metin = drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].Enabled.ToString();
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].Enabled.ToString();
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].Enabled.ToString();
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].Enabled.ToString();
                        if (Tür.Text == "TagName")
                            metin = drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].Enabled.ToString();
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi." + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "GetAttribute")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].GetAttribute(metot_veri.Text);
                        if (Tür.Text == "Id")
                            metin = drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].GetAttribute(metot_veri.Text);
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].GetAttribute(metot_veri.Text);
                        if (Tür.Text == "Name")
                            metin = drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].GetAttribute(metot_veri.Text);
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].GetAttribute(metot_veri.Text);
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].GetAttribute(metot_veri.Text);
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].GetAttribute(metot_veri.Text);
                        if (Tür.Text == "TagName")
                            drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].GetAttribute(metot_veri.Text);
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi : " + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "GetCssValue")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].GetCssValue(metot_veri.Text);
                        if (Tür.Text == "Id")
                            metin = drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].GetCssValue(metot_veri.Text);
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].GetCssValue(metot_veri.Text);
                        if (Tür.Text == "Name")
                            metin = drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].GetCssValue(metot_veri.Text);
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].GetCssValue(metot_veri.Text);
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].GetCssValue(metot_veri.Text);
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].GetCssValue(metot_veri.Text);
                        if (Tür.Text == "TagName")
                            metin = drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].GetCssValue(metot_veri.Text);
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi : " + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "GetHashCode")
                {
                    try
                    {
                        int metin = 0;
                        if (Tür.Text == "XPath")
                            metin = drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].GetHashCode();
                        if (Tür.Text == "Id")
                            metin = drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].GetHashCode();
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].GetHashCode();
                        if (Tür.Text == "Name")
                            metin = drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].GetHashCode();
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].GetHashCode();
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].GetHashCode();
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].GetHashCode();
                        if (Tür.Text == "TagName")
                            metin = drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].GetHashCode();
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi :" + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "GetProperty")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].GetProperty(metot_veri.Text);
                        if (Tür.Text == "Id")
                            metin = drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].GetProperty(metot_veri.Text);
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].GetProperty(metot_veri.Text);
                        if (Tür.Text == "Name")
                            metin = drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].GetProperty(metot_veri.Text);
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].GetProperty(metot_veri.Text);
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].GetProperty(metot_veri.Text);
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].GetProperty(metot_veri.Text);
                        if (Tür.Text == "TagName")
                            drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].GetAttribute(metot_veri.Text);
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi : " + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "Location")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].Location.ToString();
                        if (Tür.Text == "Id")
                            metin = drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].Location.ToString();
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].Location.ToString();
                        if (Tür.Text == "Name")
                            metin = drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].Location.ToString();
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].Location.ToString();
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].Location.ToString();
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].Location.ToString();
                        if (Tür.Text == "TagName")
                            metin = drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].Location.ToString();
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi." + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }

                }
                if (Metotlar.Text == "Selected")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].Selected.ToString();
                        if (Tür.Text == "Id")
                            metin = drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].Selected.ToString();
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].Selected.ToString();
                        if (Tür.Text == "Name")
                            metin = drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].Selected.ToString();
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].Selected.ToString();
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].Selected.ToString();
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].Selected.ToString();
                        if (Tür.Text == "TagName")
                            metin = drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].Selected.ToString();
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi." + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "Size")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].Size.ToString();
                        if (Tür.Text == "Id")
                            metin = drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].Size.ToString();
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].Size.ToString();
                        if (Tür.Text == "Name")
                            metin = drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].Size.ToString();
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].Size.ToString();
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].Size.ToString();
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].Size.ToString();
                        if (Tür.Text == "TagName")
                            metin = drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].Size.ToString();
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi." + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "Submit")
                {
                    try
                    {
                        if (Tür.Text == "XPath")
                            drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].Submit();
                        if (Tür.Text == "Id")
                            drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].Submit();
                        if (Tür.Text == "CssSelector")
                            drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].Submit();
                        if (Tür.Text == "Name")
                            drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].Submit();
                        if (Tür.Text == "LinkText")
                            drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].Submit();
                        if (Tür.Text == "ClassName")
                            drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].Submit();
                        if (Tür.Text == "PartialLinkText")
                            drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].Submit();
                        if (Tür.Text == "TagName")
                            drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].Submit();
                        Console.Items.Add(DateTime.Now + ": Butona başarıyla tıklatıldı.");
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Butona tıklatılamadı. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "TagName")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].TagName;
                        if (Tür.Text == "Id")
                            metin = drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].TagName;
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].TagName;
                        if (Tür.Text == "Name")
                            metin = drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].TagName;
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].TagName;
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].TagName;
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].TagName;
                        if (Tür.Text == "TagName")
                            metin = drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].TagName;
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi : " + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
                if (Metotlar.Text == "ToString")
                {
                    try
                    {
                        string metin = "";
                        if (Tür.Text == "XPath")
                            metin = drv.FindElements(By.XPath(veri.Text))[Convert.ToInt32(count.Text)].ToString();
                        if (Tür.Text == "Id")
                            metin = drv.FindElements(By.Id(veri.Text))[Convert.ToInt32(count.Text)].ToString();
                        if (Tür.Text == "CssSelector")
                            metin = drv.FindElements(By.CssSelector(veri.Text))[Convert.ToInt32(count.Text)].ToString();
                        if (Tür.Text == "Name")
                            metin = drv.FindElements(By.Name(veri.Text))[Convert.ToInt32(count.Text)].ToString();
                        if (Tür.Text == "LinkText")
                            metin = drv.FindElements(By.LinkText(veri.Text))[Convert.ToInt32(count.Text)].ToString();
                        if (Tür.Text == "ClassName")
                            metin = drv.FindElements(By.ClassName(veri.Text))[Convert.ToInt32(count.Text)].ToString();
                        if (Tür.Text == "PartialLinkText")
                            metin = drv.FindElements(By.PartialLinkText(veri.Text))[Convert.ToInt32(count.Text)].ToString();
                        if (Tür.Text == "TagName")
                            metin = drv.FindElements(By.TagName(veri.Text))[Convert.ToInt32(count.Text)].ToString();
                        Console.Items.Add(DateTime.Now + ": Veri başarıyla çekildi : " + metin);
                    }
                    catch (Exception ex)
                    {
                        Console.Items.Add(DateTime.Now + ": Veri çekilemedi. Hata :" + ex);
                    }
                }
            }
        }

        private void kodeditör_Tick(object sender, EventArgs e)
        {
            if (kopyalamak.Checked == true)
            {
                if (radioButton1.Checked == true)
                {
                    if (site.Text != Clipboard.GetText() && Clipboard.GetText() != "null")
                    {
                        site.Text = Clipboard.GetText();
                        Clipboard.SetText("null");
                        Console.Items.Add(DateTime.Now + ": Kopyalanan veri : " + site.Text);
                    }
                }
                else
                {
                    if (veri.Text != Clipboard.GetText() && Clipboard.GetText() != "null")
                    {
                        veri.Text = Clipboard.GetText();
                        Clipboard.SetText("null");
                        Console.Items.Add(DateTime.Now + ": Kopyalanan veri : " + veri.Text);
                    }
                }
            }
            string kod = "drv.";
            if (element.Checked == true)
            {
                kod += "FindElement(By.";
                kod += Tür.Text + "('" + veri.Text + "'))";
                if (Metotlar.Text == "Text")
                    kod += ".Text;";
                if (Metotlar.Text == "Click")
                    kod += ".Click();";
                if (Metotlar.Text == "SendKeys")
                    kod += ".SendKeys('" + metot_veri.Text + "');";
                if (Metotlar.Text == "Clear")
                    kod += ".Clear();";
                if (Metotlar.Text == "Displayed")
                    kod += ".Displayed.ToString();";
                if (Metotlar.Text == "Enabled")
                    kod += ".Enabled.ToString();";
                if (Metotlar.Text == "GetAttribute")
                    kod += ".GetAttribute('" + metot_veri.Text + "');";
                if (Metotlar.Text == "GetCssValue")
                    kod += ".GetCssValue('" + metot_veri.Text + "');";
                if (Metotlar.Text == "GetHashCode")
                    kod += ".GetHashCode();";
                if (Metotlar.Text == "GetProperty")
                    kod += ".GetProperty('" + metot_veri.Text + "');";
                if (Metotlar.Text == "GetType")
                    kod += ".GetType();";
                if (Metotlar.Text == "Location")
                    kod += ".Location.ToString();";
                if (Metotlar.Text == "Selected")
                    kod += ".Selected.ToString();";
                if (Metotlar.Text == "Size")
                    kod += ".Size.ToString();";
                if (Metotlar.Text == "Submit")
                    kod += ".Submit();";
                if (Metotlar.Text == "TagName")
                    kod += ".TagName;";
                if (Metotlar.Text == "ToString")
                    kod += ".ToString;";
            }
            if (elements.Checked == true)
            {
                kod += "FindElements(By.";
                kod += Tür.Text + "('" + veri.Text + "'))";
                if (Metotlar.Text != "Count")
                {
                    if (count.Text == "")
                        kod += "[0]";
                    else
                    kod += "[" + count.Text + "]";
                }

                if (Metotlar.Text == "Text")
                    kod += ".Text;";
                if (Metotlar.Text == "Click")
                    kod += ".Click();";
                if (Metotlar.Text == "SendKeys")
                    kod += ".SendKeys('"+metot_veri.Text +"');";
                if (Metotlar.Text == "Clear")
                    kod += ".Clear();";
                if (Metotlar.Text == "Displayed")
                    kod += ".Displayed.ToString();";
                if (Metotlar.Text == "Enabled")
                    kod += ".Enabled.ToString();";
                if (Metotlar.Text == "GetAttribute")
                    kod += ".GetAttribute('"+metot_veri.Text+"');";
                if (Metotlar.Text == "GetCssValue")
                    kod += ".GetCssValue('" + metot_veri.Text + "');";
                if (Metotlar.Text == "GetHashCode")
                    kod += ".GetHashCode();";
                if (Metotlar.Text == "GetProperty")
                    kod += ".GetProperty('" + metot_veri.Text + "');";
                if (Metotlar.Text == "GetType")
                    kod += ".GetType();";
                if (Metotlar.Text == "Location")
                    kod += ".Location.ToString();";
                if (Metotlar.Text == "Selected")
                    kod += ".Selected.ToString();";
                if (Metotlar.Text == "Size")
                    kod += ".Size.ToString();";
                if (Metotlar.Text == "Submit")
                    kod += ".Submit();";
                if (Metotlar.Text == "TagName")
                    kod += ".TagName;";
                if (Metotlar.Text == "ToString")
                    kod += ".ToString;";
            }
            Kod.Text = kod;
        }

        private void count_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                checkBox1.Text = "Chrome.Visible = True;";
                drv.Manage().Window.FullScreen();
                button4.Visible = false;
                button5.Visible = true;
            }
            else
            {
                checkBox1.Text = "Chrome.Visible = False;";
                drv.Manage().Window.Position = new Point(-32000, -32000);
                button4.Visible = true;
                button5.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                drv.Navigate().GoToUrl(site.Text);
                drv.Manage().Window.FullScreen();
            }
            catch (Exception ex){
                Console.Items.Add("Hata : " + ex);
            }
        }

        private void Console_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Console.Text != "")
            consoleyardimcisi.Text = Console.Text;
                button3.Visible = true;
                consoleyardimcisi.Visible = true;
            Console.SelectedIndex = -1;
        }
        bool mobileemü = false;
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string dosya_yolu = @"settings.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Metot:"+Metotlar.Text);
            sw.WriteLine("Tür:"+Tür.Text);
            if (element.Checked==true)
            sw.WriteLine("Element:true");
            else
                sw.WriteLine("Element:false");
            if (elements.Checked == true)
                sw.WriteLine("Elements:true");
            else
                sw.WriteLine("Elements:false");
            if (site.Text == "")
                sw.WriteLine("Site:https://kodzamani.weebly.com");
            else
            sw.WriteLine("Site:"+site.Text);
            if (metot_veri.Text == "")
                sw.WriteLine("Veri:null");
            else
                sw.WriteLine("Veri:" + metot_veri.Text);
            if (checkBox1.Checked==true)
            sw.WriteLine("Visible:true");
            else
                sw.WriteLine("Visible:false");
            if (kopyalamak.Checked==true)
            {
                if (radioButton2.Checked == true)
                {
                    sw.WriteLine("Kopyala:true/element");
                    sw.WriteLine("Kopyala:false/site");
                }
                else
                {
                    sw.WriteLine("Kopyala:true/site");
                    sw.WriteLine("Kopyala:false/element");
                }
            }
            else
            sw.WriteLine("Kopyala:false");
            if (mobileemü == true)
            sw.WriteLine("Mobile:true");
            else
                sw.WriteLine("Mobile:false");
                sw.WriteLine("Delay:"+kodeditör.Interval);
            sw.Flush();
            sw.Close();
            fs.Close();
            try
            {
                drv.Close();
                drv.Quit();
            }
            catch { }
        }

        private void kopyalamak_CheckedChanged(object sender, EventArgs e)
        {
            if (kopyalamak.Checked == false)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            consoleyardimcisi.Visible = false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void site_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== System.Windows.Forms.Keys.Enter)
                button2.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox1.Text = "Chrome.Visible = True;";
            drv.Manage().Window.FullScreen();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox1.Text = "Chrome.Visible = False;";
            drv.Manage().Window.Position = new Point(-32000, -32000);
        }
    }
}
