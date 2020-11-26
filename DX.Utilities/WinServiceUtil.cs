using System;
using System.Collections;
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Utilities
{
    public class WinServiceUtil
    {
        /// <summary>
        /// 服务是否存在
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public bool IsServiceExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName == serviceName)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="serviceName"></param>
        public void StartService(string serviceName)
        {
            if (IsServiceExisted(serviceName))
            {
                System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController(serviceName);
                if (service.Status != System.ServiceProcess.ServiceControllerStatus.Running &&
                    service.Status != System.ServiceProcess.ServiceControllerStatus.StartPending)
                {
                    try
                    {
                        service.Start();
                    }
                    catch (Exception ex)
                    {
                        string str = ex.Message;
                    }
                    for (int i = 0; i < 60; i++)
                    {
                        service.Refresh();
                        System.Threading.Thread.Sleep(1000);
                        if (service.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                        {
                            break;
                        }
                        if (i == 59)
                        {
                            throw new Exception("Start Service Error：" + serviceName);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="serviceName"></param>
        public void StopService(string serviceName)
        {
            if (IsServiceExisted(serviceName))
            {
                System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController(serviceName);
                if (service.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                {
                    service.Stop();
                    for (int i = 0; i < 60; i++)
                    {
                        service.Refresh();
                        System.Threading.Thread.Sleep(1000);
                        if (service.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                        {
                            break;
                        }
                        if (i == 59)
                        {
                            throw new Exception("Stop Service Error：" + serviceName);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 重启服务
        /// </summary>
        /// <param name="serviceName"></param>
        public void RestartService(string serviceName)
        {
            try
            {
                System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController(serviceName);
                if (service.Status == ServiceControllerStatus.Running)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                }
                service.Refresh();
                System.Threading.Thread.Sleep(1000);
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 获取服务状态
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public ServiceControllerStatus GetServiceStatus(string serviceName)
        {
            System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController(serviceName);
            return service.Status;
        }

        /// <summary>
        /// 配置服务：安装或卸载
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="install"></param>
        public bool ConfigService(string serviceName, string description, string location, bool install)
        {
            TransactedInstaller ti = new TransactedInstaller();
            ti.Installers.Add(new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem
            });
            ti.Installers.Add(new ServiceInstaller
            {
                DisplayName = serviceName,
                ServiceName = serviceName,
                Description = description,
                //ServicesDependedOn = new string[] { "MSSQLSERVER" },//前置服务
                StartType = ServiceStartMode.Automatic//运行方式
            });
            ti.Context = new InstallContext();
            ti.Context.Parameters["assemblypath"] = location;
            try
            {
                if (install)
                {
                    ti.Install(new Hashtable());
                }
                else
                {
                    ti.Uninstall(null);
                }
                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }

        }        
    }
}
