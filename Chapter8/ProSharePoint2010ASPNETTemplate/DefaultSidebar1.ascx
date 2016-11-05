<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DefaultSidebar1.ascx.cs" Inherits="Sidebar1" %>
<%@ Import Namespace="ProSharePoint2010" %>
<%@ Register TagPrefix="pro" Namespace="ProSharePoint2010" %>
<%@ Register TagPrefix="art" TagName="DefaultVerticalMenu" Src="DefaultVerticalMenu.ascx" %>

<art:DefaultVerticalMenu ID="DefaultVMenuContent" runat="server" />
                  <pro:Block ID="NewsletterBlock" Caption="Newsletter" runat="server"><ContentTemplate><div>
          <input type="text" value="" name="email" id="s" style="width: 95%;" />
          <span class="art-button-wrapper">
          	<span class="l"> </span>
          	<span class="r"> </span>
          	<input class="art-button" type="submit" name="search" value="Subscribe" />
          </span>
          
          </div>
             </ContentTemplate></pro:Block><pro:Block ID="HighlightsBlock" Caption="Highlights" runat="server"><ContentTemplate><div>
                            <ul><li><b>Jun 14, 2008</b>
                            <p>Aliquam sit amet felis. Mauris semper,
                                  velit semper laoreet dictum, quam
                                  diam dictum urna, nec placerat elit
                                  nisl in quam. Etiam augue pede,
                                  molestie eget, rhoncus at, convallis
                                  ut, eros. Aliquam pharetra.<br />
                                  <a href="#">Read more...</a>
                            </p></li></ul>
                            <ul><li><b>Aug 24, 2008</b>
                            <p>Aliquam sit amet felis. Mauris semper,
                                  velit semper laoreet dictum, quam
                                  diam dictum urna, nec placerat elit
                                  nisl in quam. Etiam augue pede,
                                  molestie eget, rhoncus at, convallis
                                  ut, eros. Aliquam pharetra.<br />
                                  <a href="#">Read more...</a>
                            </p></li></ul>
                            </div>
             </ContentTemplate></pro:Block><pro:Block ID="ContactInformationBlock" Caption="Contact Info" runat="server"><ContentTemplate><div>
                <img src="images/contact.jpg" alt="an image" style="margin: 0 auto;display:block;width:95%" />
          <br />
          <b>Company Co.</b><br />
          Las Vegas, NV 12345<br />
          Email: <a href="mailto:info@company.com">info@company.com</a><br />
          <br />
          Phone: (123) 456-7890 <br />
          Fax: (123) 456-7890
          </div>
             </ContentTemplate></pro:Block>
