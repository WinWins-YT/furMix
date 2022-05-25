@echo off
echo Setting Web port...
netsh http add urlacl url=http://+:%1/ user=%3
netsh http add urlacl url=http://*:%1/ user=%3