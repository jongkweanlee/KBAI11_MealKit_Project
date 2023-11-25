using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//웹 주소 연동시 필요
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace MealKit
{
    //웹 주소 연동시 필요
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    //[ComVisible(true)]
    public partial class DAUM_Api_ZipCode : Form
    {
        #region "FORM_LOAD"
        private int intLFrmLoading = 0; // 폼로드여부
        public DAUM_Api_ZipCode()
        {
            InitializeComponent();
        }

        private void DAUM_Api_ZipCode_Load(object sender, EventArgs e)
        {
            try
            {
                intLFrmLoading = 1;
                //string strhtml = lfn_html();
                //webBrowser1.DocumentText = strhtml; // html문서를 심을시.. 오류가 남
                webBrowser1.Navigate("https://jongkweanlee.github.io/ZipCodeHosting/zipcode.html");
                webBrowser1.ObjectForScripting = this;

                this.Tag = null;
                //timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                Base_Message(ex);
            }

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (intLFrmLoading.Equals(1))
            {
                timer1.Enabled = true;
            } //처음폼 로드시만...실행
            intLFrmLoading = 0;
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            wb_size(); //사이즈변경

        }

        #endregion //FORM_LOAD

        #region "Size"

        #region "EVENT"

        private void webBrowser1_Resize(object sender, EventArgs e)
        {
            wb_size();
        }
        #endregion

        private void wb_size()
        {
            try
            {
                int w;
                int h;

                w = webBrowser1.Width;
                h = webBrowser1.Height;

                w = w - 40;
                h = h - 40;

                if (w < 1) { w = 0; }
                if (h < 1) { h = 0; }

                if (w > 0 && h > 0) { lfn_Cshap_WEB_initLayerPosition(w, h); } //웹페이지 사이즈조정 실행
            }
            catch (Exception ex)
            {
                Base_Message(ex);
            }
        }

        #endregion

        #region "FUN"


        //WEB -> C#
        public void lfn_WEB_Cshap_Script2(
                                                         object obj01, object obj02, object obj03, object obj04, object obj05, object obj06, object obj07, object obj08, object obj09
                                         , object obj10, object obj11, object obj12, object obj13, object obj14, object obj15, object obj16, object obj17, object obj18, object obj19
                                         , object obj20, object obj21, object obj22, object obj23, object obj24, object obj25, object obj26, object obj27, object obj28, object obj29
                                         , object obj30, object obj31, object obj32, object obj33
                                         )
        {
            try
            {
                #region "변수선언"
                string val01 = (string)obj01;
                string val02 = (string)obj02;
                string val03 = (string)obj03;
                string val04 = (string)obj04;
                string val05 = (string)obj05;
                string val06 = (string)obj06;
                string val07 = (string)obj07;
                string val08 = (string)obj08;
                string val09 = (string)obj09;

                string val10 = (string)obj10;
                string val11 = (string)obj11;
                string val12 = (string)obj12;
                string val13 = (string)obj13;
                string val14 = (string)obj14;
                string val15 = (string)obj15;
                string val16 = (string)obj16;
                string val17 = (string)obj17;
                string val18 = (string)obj18;
                string val19 = (string)obj19;

                string val20 = (string)obj20;
                string val21 = (string)obj21;
                string val22 = (string)obj22;
                string val23 = (string)obj23;
                string val24 = (string)obj24;
                string val25 = (string)obj25;
                string val26 = (string)obj26;
                string val27 = (string)obj27;
                string val28 = (string)obj28;
                string val29 = (string)obj29;

                string val30 = (string)obj30;
                string val31 = (string)obj31;
                string val32 = (string)obj32;
                string val33 = (string)obj33;

                string strADDR1 = "";
                //string strADDR2 = "";
                string strEX = "";
                #endregion
                string strTMP1 = "";


                DataRow dr = null;
                lfn_dr(ref dr);

                #region "dr<-변수기입1"
                dr["zonecode"] = val01;
                dr["address"] = val02;
                dr["addressEnglish"] = val03;
                dr["addressType"] = val04;
                dr["userSelectedType"] = val05;

                dr["noSelected"] = val06;
                dr["userLanguageType"] = val07;
                dr["roadAddress"] = val08;
                dr["roadAddressEnglish"] = val09;
                dr["jibunAddress"] = val10;

                dr["jibunAddressEnglish"] = val11;
                dr["autoRoadAddress"] = val12;
                dr["autoRoadAddressEnglish"] = val13;
                dr["autoJbunAddress"] = val14;
                dr["autoJibunAddressEnglish"] = val15;

                dr["buildngCode"] = val16;
                dr["buildingName"] = val17;
                dr["apartment"] = val18;
                dr["sido"] = val19;
                dr["sigungu"] = val20;

                dr["sigunguCode"] = val21;
                dr["roadnameCode"] = val22;
                dr["bcode"] = val23;
                dr["roadname"] = val24;
                dr["bname"] = val25;

                dr["bname1"] = val26;
                dr["bname2"] = val27;
                dr["hname"] = val28;
                dr["query"] = val29;
                dr["postcode"] = val30;

                dr["postcode1"] = val31;
                dr["postcode2"] = val32;
                dr["postcodeSeq"] = val33;
                #endregion

                #region "ADDR1, ADDR2 X, EX 산출"
                try
                {
                    // 검색결과 항목을 클릭했을때 실행할 코드를 작성하는 부분.
                    // 각 주소의 노출 규칙에 따라 주소를 조합한다.
                    // 내려오는 변수가 값이 없는 경우엔 공백('')값을 가지므로, 이를 참고하여 분기 한다.
                    strADDR1 = ""; // 주소 변수
                    strEX = ""; // 참고항목 변수

                    //주소변수1
                    if (dr["userSelectedType"].Equals("R"))
                    {
                        strADDR1 = dr["roadAddress"].ToString();   // 사용자가 도로명 주소를 선택했을 경우
                    }
                    else
                    {
                        strADDR1 = dr["jibunAddress"].ToString();  // 사용자가 지번 주소를 선택했을 경우(J)
                    }

                    // 참고항목변수
                    // 사용자가 선택한 주소가 도로명 타입일때 참고항목을 조합한다.
                    if (dr["userSelectedType"].Equals("R"))
                    {
                        strTMP1 = dr["bname"].ToString();
                        if (!strTMP1.Equals("")) { strTMP1 = strTMP1.Substring(strTMP1.Length - 1, 1).ToString(); }
                        if (!dr["bname"].Equals("") && (strTMP1.Equals("동") || strTMP1.Equals("로") || strTMP1.Equals("가")))
                        {
                            strEX += dr["bname"].ToString();
                        }

                        if (!dr["buildingName"].Equals("") && dr["apartment"].Equals("Y"))
                        { // 건물명이 있고, 공동주택일 경우 추가한다.
                            if (!strEX.Equals("")) { strEX += ", "; }
                            strEX += dr["buildingName"].ToString();
                        }

                        if (!strEX.Equals("")) { strEX = "(" + strEX + ")"; }

                    }
                    else
                    {
                        strEX = "";
                    }
                }
                catch { }
                #endregion

                #region "dr<=정제된데이터 (ADDR1, ADDR2, EX)"
                dr["ADDR1"] = strADDR1;
                dr["EX"] = strEX;
                #endregion
                this.Tag = dr;
                this.Close();
            }
            catch (Exception ex)
            {
                Base_Message(ex);
            }
        }

        private void lfn_dr(ref DataRow dr)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("zonecode");
                dt.Columns.Add("address");
                dt.Columns.Add("addressEnglish");
                dt.Columns.Add("addressType");
                dt.Columns.Add("userSelectedType");

                dt.Columns.Add("noSelected");
                dt.Columns.Add("userLanguageType");
                dt.Columns.Add("roadAddress");
                dt.Columns.Add("roadAddressEnglish");
                dt.Columns.Add("jibunAddress");

                dt.Columns.Add("jibunAddressEnglish");
                dt.Columns.Add("autoRoadAddress");
                dt.Columns.Add("autoRoadAddressEnglish");
                dt.Columns.Add("autoJbunAddress");
                dt.Columns.Add("autoJibunAddressEnglish");

                dt.Columns.Add("buildngCode");
                dt.Columns.Add("buildingName");
                dt.Columns.Add("apartment");
                dt.Columns.Add("sido");
                dt.Columns.Add("sigungu");

                dt.Columns.Add("sigunguCode");
                dt.Columns.Add("roadnameCode");
                dt.Columns.Add("bcode");
                dt.Columns.Add("roadname");
                dt.Columns.Add("bname");

                dt.Columns.Add("bname1");
                dt.Columns.Add("bname2");
                dt.Columns.Add("hname");
                dt.Columns.Add("query");
                dt.Columns.Add("postcode");

                dt.Columns.Add("postcode1");
                dt.Columns.Add("postcode2");
                dt.Columns.Add("postcodeSeq");

                dt.Columns.Add("ADDR1");
                dt.Columns.Add("EX");

                dr = dt.NewRow();
            }
            catch (Exception ex)
            {
                Base_Message(ex);
            }
        }

        //C# -> WEB
        private void lfn_Cshap_WEB_initLayerPosition(int w, int h)
        {
            //webBrowser1.Document.InvokeScript("initLayerPosition", new object[] { w, h }); //웹 자바스크립트에전달
        }

        private void lfn_Cshap_WEB_Script2()
        {
            string str1 = "A";
            string str2 = "B";

            webBrowser1.Document.InvokeScript("Cshap_WEB_Script2", new object[] { str1, str2 }); //웹 자바스크립트에전달
            //webBrowser1.Document.InvokeScript("CallScript", new object[] { svalue1, svalue2 });
        }

        #endregion //FUN


        #region "Message"
        public void Base_Message(Exception ex)
        {
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
        }
        public void Base_Message(string messgage)
        {
            MessageBox.Show(messgage, "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
        }

        #endregion

        private string lfn_html()
        {
            string strhtml = "";
            strhtml += "<html>";
            strhtml += "<body onload='sample2_execDaumPostcode()'>";
            //<!-- iOS에서는 position:fixed 버그가 있음, 적용하는 사이트에 맞게 position:absolute 등을 이용하여 top,left값 조정 필요 -->
            strhtml += "<div id='layer' style='position:fixed;overflow:hidden;z-index:1;-webkit-overflow-scrolling:touch;'></div>";
            strhtml += "<script src='http://t1.daumcdn.net/mapjsapi/bundle/postcode/prod/postcode.v2.js'></script>";
            strhtml += "<script>";
            // 우편번호 찾기 화면을 넣을 element
            strhtml += "var element_layer = document.getElementById('layer');";

            //창열기
            strhtml += "function sample2_execDaumPostcode() {";
            strhtml += "new daum.Postcode({";
            //strhtml += "onresize:function(size) {";
            //initLayerPosition(size.width,size.height);
            //strhtml += "},";
            strhtml += "oncomplete: function(data) {";

            strhtml += "WEB_Cshap_Script2(";
            strhtml += " data.zonecode             ,data.address           ,data.addressEnglish         , data.addressType         ,data.userSelectedType";
            strhtml += ",data.noSelected           ,data.userLanguageType  ,data.roadAddress            , data.roadAddressEnglish  ,data.jibunAddress";
            strhtml += ",data.jibunAddressEnglish  ,data.autoRoadAddress   ,data.autoRoadAddressEnglish , data.autoJbunAddress     ,data.autoJibunAddressEnglish";
            strhtml += ",data.buildngCode          ,data.buildingName      ,data.apartment              , data.sido                ,data.sigungu";
            strhtml += ",data.sigunguCode          ,data.roadnameCode      ,data.bcode                  , data.roadname            ,data.bname";
            strhtml += ",data.bname1               ,data.bname2            ,data.hname                  , data.query               ,data.postcode";
            strhtml += ",data.postcode1            ,data.postcode2         ,data.postcodeSeq";
            strhtml += ");";
            // iframe을 넣은 element를 안보이게 한다.
            // (autoClose:false 기능을 이용한다면, 아래 코드를 제거해야 화면에서 사라지지 않는다.)
            strhtml += "element_layer.style.display = 'none';";
            strhtml += "},";
            strhtml += "width : '100%',";
            strhtml += "height : '100%',";
            strhtml += "maxSuggestItems : 5";
            strhtml += "}).embed(element_layer);";
            // iframe을 넣은 element를 보이게 한다.
            strhtml += "element_layer.style.display = 'block';";
            // iframe을 넣은 element의 위치를 화면의 가운데로 이동시킨다.
            strhtml += "initLayerPosition(600,400);";
            strhtml += "}";
            // 브라우저의 크기 변경에 따라 레이어를 가운데로 이동시키고자 하실때에는
            // resize이벤트나, orientationchange이벤트를 이용하여 값이 변경될때마다 아래 함수를 실행 시켜 주시거나,
            // 직접 element_layer의 top,left값을 수정해 주시면 됩니다.
            strhtml += "function initLayerPosition(w,h){";
            strhtml += "var width = w;";//우편번호서비스가 들어갈 element의 width
            strhtml += "var height = h;";//우편번호서비스가 들어갈 element의 height
            strhtml += "var borderWidth = 1;";//샘플에서 사용하는 border의 두께
            // 위에서 선언한 값들을 실제 element에 넣는다.
            strhtml += "element_layer.style.width = width + 'px';";
            strhtml += "element_layer.style.height = height + 'px';";
            strhtml += "element_layer.style.border = borderWidth + 'px solid';";
            // 실행되는 순간의 화면 너비와 높이 값을 가져와서 중앙에 뜰 수 있도록 위치를 계산한다.
            strhtml += "element_layer.style.left = (((window.innerWidth || document.documentElement.clientWidth) - width)/2 - borderWidth) + 'px';";
            strhtml += "element_layer.style.top = (((window.innerHeight || document.documentElement.clientHeight) - height)/2 - borderWidth) + 'px';";
            strhtml += "}";
            // ************************************************************************
            //	추가한 스크립트
            // ************************************************************************
            //C# -> WEB 전달
            //strhtml += "function Cshap_WEB_Script2(val1,val2) { alert(val1 + ' ' + val2); }";
            // WEB -> C# 전달
            strhtml += "function WEB_Cshap_Script2(val1,val2,val3,val4,val5,val6,val7,val8,val9,val10 , val11,val12,val13,val14,val15,val16,val17,val18,val19,val20 ,val21,val22,val23,val24,val25,val26,val27,val28,val29,val30  ,val31,val32,val33) ";
            strhtml += "{";
            strhtml += "if (window.external)";
            strhtml += "{";
            strhtml += "window.external.lfn_WEB_Cshap_Script2(val1,val2,val3,val4,val5,val6,val7,val8,val9,val10 ,val11,val12,val13,val14,val15,val16,val17,val18,val19,val20 ,val21,val22,val23,val24,val25,val26,val27,val28,val29,val30 ,val31,val32,val33 );";
            strhtml += "}";
            strhtml += "}";
            // ************************************************************************
            strhtml += "</script>";
            strhtml += "</body></html>";

            return strhtml;

        }
    }
}
