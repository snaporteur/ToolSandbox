import sys
from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.common.by import By
from selenium.common.exceptions import NoSuchElementException, WebDriverException
import requests

path = ""
for a in range(len(sys.argv[0].split("/")) - 1): path += sys.argv[0].split("/")[a] + "/"

js_code = """
    var attachments = document.getElementsByClassName("wpforo-attached-file");
    if (attachments.length > 0) {
        for (var i = 0; i < attachments.length; i++) {
            var attachment = attachments[i];
            var button = document.createElement("button");
            button.id = "run_script";
            button.style = "background: none; border: 1px solid black;";
            button.innerText = "Lancer le script";
            button.addEventListener("click", function() {
                window.location.href = attachment.querySelector("a").href;
            })
            attachment.appendChild(document.createElement("br"));
            attachment.appendChild(button);
        }
    }
"""

chromedriver_path = path + "chromedriver.exe"
chromebinary_path = path + "chrome/chrome.exe"

chrome_options = Options()
chrome_options.binary_location = chromebinary_path
chrome_options.add_argument("--no-sandbox")
chrome_options.add_argument("--disable-infobars")
chrome_options.add_argument("--ignore-certificate-errors")
chrome_options.add_argument("--disable-web-security")
chrome_options.add_argument("--app=https://tool-sandbox.000.pe/community/script")

service = Service(chromedriver_path)
driver = webdriver.Chrome(service=service, options=chrome_options)

while_running = True
while while_running:
    try:
        if driver.current_url.endswith(".lua"):
            text = driver.find_element(By.XPATH, "/html/body/pre").text
            
            with open(path + "dscript.lua", "w") as f:
                f.write(text)
            
            driver.back()
            requests.get("http://127.0.0.1:8080/run")
        
        driver.find_element(By.ID, "run_script")
    except NoSuchElementException:
        driver.execute_script(js_code)
    except:
        while_running = False