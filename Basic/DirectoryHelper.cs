using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CLib.Basic
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	DirectoryHelper
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.Basic
     * 文 件 名:	DirectoryHelper
     * 创建时间:	2013/2/22 11:58:07
     * 作    者:	常伟华 Changweihua
	 * 版    权:	DirectoryHelper说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	0d2524c3-4ecb-4dd7-803b-bd28cf6fd90e  
	 *
	 * 登录用户:	Changweihua
	 * 所 属 域:	Lumia800

	 * 创建年份:	2013
     * 修改时间:
     * 修 改 人:
     * 
     ************************************************************************************/
    #endregion

    /// <summary>
    /// 摘要
    /// </summary>
    class DirectoryHelper
    {
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dirFullPath">文件夹路径</param>
        /// <param name="dirOperateOption">文件夹操作选项</param>
        /// <returns>True/False</returns>
        public bool CreateDirOperate(string dirFullPath, OperateOption dirOperateOption)
        {
            try
            {
                if (!Directory.Exists(dirFullPath))
                {
                    Directory.CreateDirectory(dirFullPath);
                }
                else if (dirOperateOption == OperateOption.ExistDelete)
                {
                    Directory.Delete(dirFullPath, true);
                    Directory.CreateDirectory(dirFullPath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除文件夹操作
        /// </summary>
        /// <param name="dirFullPath">文件夹路径</param>
        /// <returns>True/False</returns>
        public bool DeleteDirOperate(string dirFullPath)
        {
            if (Directory.Exists(dirFullPath))
            {
                Directory.Delete(dirFullPath, true);
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到文件夹下的所有文件，不包含子文件夹
        /// </summary>
        /// <param name="dirFullPath">文件夹路径</param>
        /// <returns>string[]</returns>
        /// <remarks></remarks>
        public string[] GetDirFiles(string dirFullPath)
        {
            string[] fileList = null;
            if (Directory.Exists(dirFullPath))
            {
                return fileList = Directory.GetFiles(dirFullPath, "*.*", SearchOption.TopDirectoryOnly);

            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到文件夹下的所有文件，按指定的搜索模式
        /// </summary>
        /// <param name="dirFullPath">文件夹路径</param>
        /// <param name="so">搜索类型</param>
        /// <returns>string[]</returns>
        /// <remarks></remarks>
        public string[] GetDirFiles(string dirFullPath, SearchOption searchOption)
        {
            string[] fileList = null;
            if (Directory.Exists(dirFullPath))
            {
                return fileList = Directory.GetFiles(dirFullPath, "*.*", searchOption);

            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到文件夹下所有与文件类型匹配的文件
        /// </summary>
        /// <param name="dirFullPath">文件夹路径</param>
        /// <param name="SearchPattern">文件类型</param>
        /// <returns></returns>
        public string[] GetDirFiles(string dirFullPath, string SearchPattern)
        {
            string[] fileList = null;
            if (Directory.Exists(dirFullPath))
            {
                return fileList = Directory.GetFiles(dirFullPath, SearchPattern);

            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到文件夹下所有文件
        /// </summary>
        /// <param name="dirFullPath">文件夹路径</param>
        /// <param name="SearchPattern">文件类型</param>
        /// <param name="so">搜索类型</param>
        /// <returns>string[]</returns>
        /// <remarks></remarks>
        public string[] GetDirFiles(string dirFullPath, string SearchPattern, SearchOption searchOption)
        {
            string[] fileList = null;
            if (Directory.Exists(dirFullPath))
            {
                return fileList = Directory.GetFiles(dirFullPath, SearchPattern, searchOption);

            }
            else
            {
                return null;
            }
        }
    }

    public enum OperateOption
    {
        /// <summary>
        /// 文件夹存在时删除
        /// </summary>
        ExistDelete,
        /// <summary>
        /// 文件夹存在时返回
        /// </summary>
        ExistReturn
    }

}
