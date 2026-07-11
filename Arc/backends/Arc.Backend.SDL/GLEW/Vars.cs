namespace Arc.Backend.SDL.GLEW
{
    public static class Vars
    {
        public class RefBool(bool val)
        {
            public bool Value = val;

            public static implicit operator RefBool(bool val)
            {
                return new(val);
            }
            public static implicit operator RefBool(int val)
            {
                return new(val == DotGL.GL.GL_TRUE);
            }

            public static implicit operator bool(RefBool val)
            {
                return val.Value;
            }

            public static bool operator ==(RefBool lhs, RefBool rhs)
            {
                return lhs.Value == rhs.Value;
            }
            public static bool operator !=(RefBool lhs, RefBool rhs)
            {
                return !(lhs == rhs);
            }
            public static bool operator ==(RefBool lhs, bool rhs)
            {
                return lhs.Value == rhs;
            }
            public static bool operator !=(RefBool lhs, bool rhs)
            {
                return !(lhs == rhs);
            }
            public static bool operator ==(RefBool lhs, int rhs)
            {
                return lhs.Value == (rhs == DotGL.GL.GL_TRUE);
            }
            public static bool operator !=(RefBool lhs, int rhs)
            {
                return !(lhs == rhs);
            }

            public override bool Equals(object? obj) => ReferenceEquals(this, obj) || obj switch
            {
                RefBool val => this == val,
                bool val => this == val,
                int val => this == val,
                null or _ => false,
            };

            public override int GetHashCode() => this.Value.GetHashCode();
        }

        /* error codes */
        internal const int GLEW_OK = 0;
        internal const int GLEW_NO_ERROR = 0;
        internal const int GLEW_ERROR_NO_GL_VERSION = 1;  /* missing GL version */
        internal const int GLEW_ERROR_GL_VERSION_10_ONLY = 2;  /* Need at least OpenGL 1.1 */
        internal const int GLEW_ERROR_GLX_VERSION_11_ONLY = 3;  /* Need at least GLX 1.2 */
        internal const int GLEW_ERROR_NO_GLX_DISPLAY = 4;  /* Need GLX display for GLX support */

        /* string codes */
        internal const int GLEW_VERSION = 1;
        internal const int GLEW_VERSION_MAJOR = 2;
        internal const int GLEW_VERSION_MINOR = 3;
        internal const int GLEW_VERSION_MICRO = 4;

        public static bool Experimental
        {
            get; internal set;
        }

        #region VERSION
        internal static RefBool GLEW_VERSION_4_6 = new(false);
        internal static RefBool GLEW_VERSION_4_5 = new(false);
        internal static RefBool GLEW_VERSION_4_4 = new(false);
        internal static RefBool GLEW_VERSION_4_3 = new(false);
        internal static RefBool GLEW_VERSION_4_2 = new(false);
        internal static RefBool GLEW_VERSION_4_1 = new(false);
        internal static RefBool GLEW_VERSION_4_0 = new(false);
        internal static RefBool GLEW_VERSION_3_3 = new(false);
        internal static RefBool GLEW_VERSION_3_2 = new(false);
        internal static RefBool GLEW_VERSION_3_1 = new(false);
        internal static RefBool GLEW_VERSION_3_0 = new(false);
        internal static RefBool GLEW_VERSION_2_1 = new(false);
        internal static RefBool GLEW_VERSION_2_0 = new(false);
        internal static RefBool GLEW_VERSION_1_5 = new(false);
        internal static RefBool GLEW_VERSION_1_4 = new(false);
        internal static RefBool GLEW_VERSION_1_3 = new(false);
        internal static RefBool GLEW_VERSION_1_2_1 = new(false);
        internal static RefBool GLEW_VERSION_1_2 = new(false);
        internal static RefBool GLEW_VERSION_1_1 = new(false);
        #endregion

        #region FEATURE
        internal static RefBool __GLEW_3DFX_multisample = false;
        internal static RefBool __GLEW_3DFX_tbuffer = false;
        internal static RefBool __GLEW_3DFX_texture_compression_FXT1 = false;
        internal static RefBool __GLEW_AMD_blend_minmax_factor = false;
        internal static RefBool __GLEW_AMD_compressed_3DC_texture = false;
        internal static RefBool __GLEW_AMD_compressed_ATC_texture = false;
        internal static RefBool __GLEW_AMD_conservative_depth = false;
        internal static RefBool __GLEW_AMD_debug_output = false;
        internal static RefBool __GLEW_AMD_depth_clamp_separate = false;
        internal static RefBool __GLEW_AMD_draw_buffers_blend = false;
        internal static RefBool __GLEW_AMD_framebuffer_multisample_advanced = false;
        internal static RefBool __GLEW_AMD_framebuffer_sample_positions = false;
        internal static RefBool __GLEW_AMD_gcn_shader = false;
        internal static RefBool __GLEW_AMD_gpu_shader_half_float = false;
        internal static RefBool __GLEW_AMD_gpu_shader_half_float_fetch = false;
        internal static RefBool __GLEW_AMD_gpu_shader_int16 = false;
        internal static RefBool __GLEW_AMD_gpu_shader_int64 = false;
        internal static RefBool __GLEW_AMD_interleaved_elements = false;
        internal static RefBool __GLEW_AMD_multi_draw_indirect = false;
        internal static RefBool __GLEW_AMD_name_gen_delete = false;
        internal static RefBool __GLEW_AMD_occlusion_query_event = false;
        internal static RefBool __GLEW_AMD_performance_monitor = false;
        internal static RefBool __GLEW_AMD_pinned_memory = false;
        internal static RefBool __GLEW_AMD_program_binary_Z400 = false;
        internal static RefBool __GLEW_AMD_query_buffer_object = false;
        internal static RefBool __GLEW_AMD_sample_positions = false;
        internal static RefBool __GLEW_AMD_seamless_cubemap_per_texture = false;
        internal static RefBool __GLEW_AMD_shader_atomic_counter_ops = false;
        internal static RefBool __GLEW_AMD_shader_ballot = false;
        internal static RefBool __GLEW_AMD_shader_explicit_vertex_parameter = false;
        internal static RefBool __GLEW_AMD_shader_image_load_store_lod = false;
        internal static RefBool __GLEW_AMD_shader_stencil_export = false;
        internal static RefBool __GLEW_AMD_shader_stencil_value_export = false;
        internal static RefBool __GLEW_AMD_shader_trinary_minmax = false;
        internal static RefBool __GLEW_AMD_sparse_texture = false;
        internal static RefBool __GLEW_AMD_stencil_operation_extended = false;
        internal static RefBool __GLEW_AMD_texture_gather_bias_lod = false;
        internal static RefBool __GLEW_AMD_texture_texture4 = false;
        internal static RefBool __GLEW_AMD_transform_feedback3_lines_triangles = false;
        internal static RefBool __GLEW_AMD_transform_feedback4 = false;
        internal static RefBool __GLEW_AMD_vertex_shader_layer = false;
        internal static RefBool __GLEW_AMD_vertex_shader_tessellator = false;
        internal static RefBool __GLEW_AMD_vertex_shader_viewport_index = false;
        internal static RefBool __GLEW_ANDROID_extension_pack_es31a = false;
        internal static RefBool __GLEW_ANGLE_depth_texture = false;
        internal static RefBool __GLEW_ANGLE_framebuffer_blit = false;
        internal static RefBool __GLEW_ANGLE_framebuffer_multisample = false;
        internal static RefBool __GLEW_ANGLE_instanced_arrays = false;
        internal static RefBool __GLEW_ANGLE_pack_reverse_row_order = false;
        internal static RefBool __GLEW_ANGLE_program_binary = false;
        internal static RefBool __GLEW_ANGLE_texture_compression_dxt1 = false;
        internal static RefBool __GLEW_ANGLE_texture_compression_dxt3 = false;
        internal static RefBool __GLEW_ANGLE_texture_compression_dxt5 = false;
        internal static RefBool __GLEW_ANGLE_texture_usage = false;
        internal static RefBool __GLEW_ANGLE_timer_query = false;
        internal static RefBool __GLEW_ANGLE_translated_shader_source = false;
        internal static RefBool __GLEW_APPLE_aux_depth_stencil = false;
        internal static RefBool __GLEW_APPLE_client_storage = false;
        internal static RefBool __GLEW_APPLE_clip_distance = false;
        internal static RefBool __GLEW_APPLE_color_buffer_packed_float = false;
        internal static RefBool __GLEW_APPLE_copy_texture_levels = false;
        internal static RefBool __GLEW_APPLE_element_array = false;
        internal static RefBool __GLEW_APPLE_fence = false;
        internal static RefBool __GLEW_APPLE_float_pixels = false;
        internal static RefBool __GLEW_APPLE_flush_buffer_range = false;
        internal static RefBool __GLEW_APPLE_framebuffer_multisample = false;
        internal static RefBool __GLEW_APPLE_object_purgeable = false;
        internal static RefBool __GLEW_APPLE_pixel_buffer = false;
        internal static RefBool __GLEW_APPLE_rgb_422 = false;
        internal static RefBool __GLEW_APPLE_row_bytes = false;
        internal static RefBool __GLEW_APPLE_specular_vector = false;
        internal static RefBool __GLEW_APPLE_sync = false;
        internal static RefBool __GLEW_APPLE_texture_2D_limited_npot = false;
        internal static RefBool __GLEW_APPLE_texture_format_BGRA8888 = false;
        internal static RefBool __GLEW_APPLE_texture_max_level = false;
        internal static RefBool __GLEW_APPLE_texture_packed_float = false;
        internal static RefBool __GLEW_APPLE_texture_range = false;
        internal static RefBool __GLEW_APPLE_transform_hint = false;
        internal static RefBool __GLEW_APPLE_vertex_array_object = false;
        internal static RefBool __GLEW_APPLE_vertex_array_range = false;
        internal static RefBool __GLEW_APPLE_vertex_program_evaluators = false;
        internal static RefBool __GLEW_APPLE_ycbcr_422 = false;
        internal static RefBool __GLEW_ARB_ES2_compatibility = false;
        internal static RefBool __GLEW_ARB_ES3_1_compatibility = false;
        internal static RefBool __GLEW_ARB_ES3_2_compatibility = false;
        internal static RefBool __GLEW_ARB_ES3_compatibility = false;
        internal static RefBool __GLEW_ARB_arrays_of_arrays = false;
        internal static RefBool __GLEW_ARB_base_instance = false;
        internal static RefBool __GLEW_ARB_bindless_texture = false;
        internal static RefBool __GLEW_ARB_blend_func_extended = false;
        internal static RefBool __GLEW_ARB_buffer_storage = false;
        internal static RefBool __GLEW_ARB_cl_event = false;
        internal static RefBool __GLEW_ARB_clear_buffer_object = false;
        internal static RefBool __GLEW_ARB_clear_texture = false;
        internal static RefBool __GLEW_ARB_clip_control = false;
        internal static RefBool __GLEW_ARB_color_buffer_float = false;
        internal static RefBool __GLEW_ARB_compatibility = false;
        internal static RefBool __GLEW_ARB_compressed_texture_pixel_storage = false;
        internal static RefBool __GLEW_ARB_compute_shader = false;
        internal static RefBool __GLEW_ARB_compute_variable_group_size = false;
        internal static RefBool __GLEW_ARB_conditional_render_inverted = false;
        internal static RefBool __GLEW_ARB_conservative_depth = false;
        internal static RefBool __GLEW_ARB_copy_buffer = false;
        internal static RefBool __GLEW_ARB_copy_image = false;
        internal static RefBool __GLEW_ARB_cull_distance = false;
        internal static RefBool __GLEW_ARB_debug_output = false;
        internal static RefBool __GLEW_ARB_depth_buffer_float = false;
        internal static RefBool __GLEW_ARB_depth_clamp = false;
        internal static RefBool __GLEW_ARB_depth_texture = false;
        internal static RefBool __GLEW_ARB_derivative_control = false;
        internal static RefBool __GLEW_ARB_direct_state_access = false;
        internal static RefBool __GLEW_ARB_draw_buffers = false;
        internal static RefBool __GLEW_ARB_draw_buffers_blend = false;
        internal static RefBool __GLEW_ARB_draw_elements_base_vertex = false;
        internal static RefBool __GLEW_ARB_draw_indirect = false;
        internal static RefBool __GLEW_ARB_draw_instanced = false;
        internal static RefBool __GLEW_ARB_enhanced_layouts = false;
        internal static RefBool __GLEW_ARB_explicit_attrib_location = false;
        internal static RefBool __GLEW_ARB_explicit_uniform_location = false;
        internal static RefBool __GLEW_ARB_fragment_coord_conventions = false;
        internal static RefBool __GLEW_ARB_fragment_layer_viewport = false;
        internal static RefBool __GLEW_ARB_fragment_program = false;
        internal static RefBool __GLEW_ARB_fragment_program_shadow = false;
        internal static RefBool __GLEW_ARB_fragment_shader = false;
        internal static RefBool __GLEW_ARB_fragment_shader_interlock = false;
        internal static RefBool __GLEW_ARB_framebuffer_no_attachments = false;
        internal static RefBool __GLEW_ARB_framebuffer_object = false;
        internal static RefBool __GLEW_ARB_framebuffer_sRGB = false;
        internal static RefBool __GLEW_ARB_geometry_shader4 = false;
        internal static RefBool __GLEW_ARB_get_program_binary = false;
        internal static RefBool __GLEW_ARB_get_texture_sub_image = false;
        internal static RefBool __GLEW_ARB_gl_spirv = false;
        internal static RefBool __GLEW_ARB_gpu_shader5 = false;
        internal static RefBool __GLEW_ARB_gpu_shader_fp64 = false;
        internal static RefBool __GLEW_ARB_gpu_shader_int64 = false;
        internal static RefBool __GLEW_ARB_half_float_pixel = false;
        internal static RefBool __GLEW_ARB_half_float_vertex = false;
        internal static RefBool __GLEW_ARB_imaging = false;
        internal static RefBool __GLEW_ARB_indirect_parameters = false;
        internal static RefBool __GLEW_ARB_instanced_arrays = false;
        internal static RefBool __GLEW_ARB_internalformat_query = false;
        internal static RefBool __GLEW_ARB_internalformat_query2 = false;
        internal static RefBool __GLEW_ARB_invalidate_subdata = false;
        internal static RefBool __GLEW_ARB_map_buffer_alignment = false;
        internal static RefBool __GLEW_ARB_map_buffer_range = false;
        internal static RefBool __GLEW_ARB_matrix_palette = false;
        internal static RefBool __GLEW_ARB_multi_bind = false;
        internal static RefBool __GLEW_ARB_multi_draw_indirect = false;
        internal static RefBool __GLEW_ARB_multisample = false;
        internal static RefBool __GLEW_ARB_multitexture = false;
        internal static RefBool __GLEW_ARB_occlusion_query = false;
        internal static RefBool __GLEW_ARB_occlusion_query2 = false;
        internal static RefBool __GLEW_ARB_parallel_shader_compile = false;
        internal static RefBool __GLEW_ARB_pipeline_statistics_query = false;
        internal static RefBool __GLEW_ARB_pixel_buffer_object = false;
        internal static RefBool __GLEW_ARB_point_parameters = false;
        internal static RefBool __GLEW_ARB_point_sprite = false;
        internal static RefBool __GLEW_ARB_polygon_offset_clamp = false;
        internal static RefBool __GLEW_ARB_post_depth_coverage = false;
        internal static RefBool __GLEW_ARB_program_interface_query = false;
        internal static RefBool __GLEW_ARB_provoking_vertex = false;
        internal static RefBool __GLEW_ARB_query_buffer_object = false;
        internal static RefBool __GLEW_ARB_robust_buffer_access_behavior = false;
        internal static RefBool __GLEW_ARB_robustness = false;
        internal static RefBool __GLEW_ARB_robustness_application_isolation = false;
        internal static RefBool __GLEW_ARB_robustness_share_group_isolation = false;
        internal static RefBool __GLEW_ARB_sample_locations = false;
        internal static RefBool __GLEW_ARB_sample_shading = false;
        internal static RefBool __GLEW_ARB_sampler_objects = false;
        internal static RefBool __GLEW_ARB_seamless_cube_map = false;
        internal static RefBool __GLEW_ARB_seamless_cubemap_per_texture = false;
        internal static RefBool __GLEW_ARB_separate_shader_objects = false;
        internal static RefBool __GLEW_ARB_shader_atomic_counter_ops = false;
        internal static RefBool __GLEW_ARB_shader_atomic_counters = false;
        internal static RefBool __GLEW_ARB_shader_ballot = false;
        internal static RefBool __GLEW_ARB_shader_bit_encoding = false;
        internal static RefBool __GLEW_ARB_shader_clock = false;
        internal static RefBool __GLEW_ARB_shader_draw_parameters = false;
        internal static RefBool __GLEW_ARB_shader_group_vote = false;
        internal static RefBool __GLEW_ARB_shader_image_load_store = false;
        internal static RefBool __GLEW_ARB_shader_image_size = false;
        internal static RefBool __GLEW_ARB_shader_objects = false;
        internal static RefBool __GLEW_ARB_shader_precision = false;
        internal static RefBool __GLEW_ARB_shader_stencil_export = false;
        internal static RefBool __GLEW_ARB_shader_storage_buffer_object = false;
        internal static RefBool __GLEW_ARB_shader_subroutine = false;
        internal static RefBool __GLEW_ARB_shader_texture_image_samples = false;
        internal static RefBool __GLEW_ARB_shader_texture_lod = false;
        internal static RefBool __GLEW_ARB_shader_viewport_layer_array = false;
        internal static RefBool __GLEW_ARB_shading_language_100 = false;
        internal static RefBool __GLEW_ARB_shading_language_420pack = false;
        internal static RefBool __GLEW_ARB_shading_language_include = false;
        internal static RefBool __GLEW_ARB_shading_language_packing = false;
        internal static RefBool __GLEW_ARB_shadow = false;
        internal static RefBool __GLEW_ARB_shadow_ambient = false;
        internal static RefBool __GLEW_ARB_sparse_buffer = false;
        internal static RefBool __GLEW_ARB_sparse_texture = false;
        internal static RefBool __GLEW_ARB_sparse_texture2 = false;
        internal static RefBool __GLEW_ARB_sparse_texture_clamp = false;
        internal static RefBool __GLEW_ARB_spirv_extensions = false;
        internal static RefBool __GLEW_ARB_stencil_texturing = false;
        internal static RefBool __GLEW_ARB_sync = false;
        internal static RefBool __GLEW_ARB_tessellation_shader = false;
        internal static RefBool __GLEW_ARB_texture_barrier = false;
        internal static RefBool __GLEW_ARB_texture_border_clamp = false;
        internal static RefBool __GLEW_ARB_texture_buffer_object = false;
        internal static RefBool __GLEW_ARB_texture_buffer_object_rgb32 = false;
        internal static RefBool __GLEW_ARB_texture_buffer_range = false;
        internal static RefBool __GLEW_ARB_texture_compression = false;
        internal static RefBool __GLEW_ARB_texture_compression_bptc = false;
        internal static RefBool __GLEW_ARB_texture_compression_rgtc = false;
        internal static RefBool __GLEW_ARB_texture_cube_map = false;
        internal static RefBool __GLEW_ARB_texture_cube_map_array = false;
        internal static RefBool __GLEW_ARB_texture_env_add = false;
        internal static RefBool __GLEW_ARB_texture_env_combine = false;
        internal static RefBool __GLEW_ARB_texture_env_crossbar = false;
        internal static RefBool __GLEW_ARB_texture_env_dot3 = false;
        internal static RefBool __GLEW_ARB_texture_filter_anisotropic = false;
        internal static RefBool __GLEW_ARB_texture_filter_minmax = false;
        internal static RefBool __GLEW_ARB_texture_float = false;
        internal static RefBool __GLEW_ARB_texture_gather = false;
        internal static RefBool __GLEW_ARB_texture_mirror_clamp_to_edge = false;
        internal static RefBool __GLEW_ARB_texture_mirrored_repeat = false;
        internal static RefBool __GLEW_ARB_texture_multisample = false;
        internal static RefBool __GLEW_ARB_texture_non_power_of_two = false;
        internal static RefBool __GLEW_ARB_texture_query_levels = false;
        internal static RefBool __GLEW_ARB_texture_query_lod = false;
        internal static RefBool __GLEW_ARB_texture_rectangle = false;
        internal static RefBool __GLEW_ARB_texture_rg = false;
        internal static RefBool __GLEW_ARB_texture_rgb10_a2ui = false;
        internal static RefBool __GLEW_ARB_texture_stencil8 = false;
        internal static RefBool __GLEW_ARB_texture_storage = false;
        internal static RefBool __GLEW_ARB_texture_storage_multisample = false;
        internal static RefBool __GLEW_ARB_texture_swizzle = false;
        internal static RefBool __GLEW_ARB_texture_view = false;
        internal static RefBool __GLEW_ARB_timer_query = false;
        internal static RefBool __GLEW_ARB_transform_feedback2 = false;
        internal static RefBool __GLEW_ARB_transform_feedback3 = false;
        internal static RefBool __GLEW_ARB_transform_feedback_instanced = false;
        internal static RefBool __GLEW_ARB_transform_feedback_overflow_query = false;
        internal static RefBool __GLEW_ARB_transpose_matrix = false;
        internal static RefBool __GLEW_ARB_uniform_buffer_object = false;
        internal static RefBool __GLEW_ARB_vertex_array_bgra = false;
        internal static RefBool __GLEW_ARB_vertex_array_object = false;
        internal static RefBool __GLEW_ARB_vertex_attrib_64bit = false;
        internal static RefBool __GLEW_ARB_vertex_attrib_binding = false;
        internal static RefBool __GLEW_ARB_vertex_blend = false;
        internal static RefBool __GLEW_ARB_vertex_buffer_object = false;
        internal static RefBool __GLEW_ARB_vertex_program = false;
        internal static RefBool __GLEW_ARB_vertex_shader = false;
        internal static RefBool __GLEW_ARB_vertex_type_10f_11f_11f_rev = false;
        internal static RefBool __GLEW_ARB_vertex_type_2_10_10_10_rev = false;
        internal static RefBool __GLEW_ARB_viewport_array = false;
        internal static RefBool __GLEW_ARB_window_pos = false;
        internal static RefBool __GLEW_ARM_mali_program_binary = false;
        internal static RefBool __GLEW_ARM_mali_shader_binary = false;
        internal static RefBool __GLEW_ARM_rgba8 = false;
        internal static RefBool __GLEW_ARM_shader_core_properties = false;
        internal static RefBool __GLEW_ARM_shader_framebuffer_fetch = false;
        internal static RefBool __GLEW_ARM_shader_framebuffer_fetch_depth_stencil = false;
        internal static RefBool __GLEW_ARM_texture_unnormalized_coordinates = false;
        internal static RefBool __GLEW_ATIX_point_sprites = false;
        internal static RefBool __GLEW_ATIX_texture_env_combine3 = false;
        internal static RefBool __GLEW_ATIX_texture_env_route = false;
        internal static RefBool __GLEW_ATIX_vertex_shader_output_point_size = false;
        internal static RefBool __GLEW_ATI_draw_buffers = false;
        internal static RefBool __GLEW_ATI_element_array = false;
        internal static RefBool __GLEW_ATI_envmap_bumpmap = false;
        internal static RefBool __GLEW_ATI_fragment_shader = false;
        internal static RefBool __GLEW_ATI_map_object_buffer = false;
        internal static RefBool __GLEW_ATI_meminfo = false;
        internal static RefBool __GLEW_ATI_pn_triangles = false;
        internal static RefBool __GLEW_ATI_separate_stencil = false;
        internal static RefBool __GLEW_ATI_shader_texture_lod = false;
        internal static RefBool __GLEW_ATI_text_fragment_shader = false;
        internal static RefBool __GLEW_ATI_texture_compression_3dc = false;
        internal static RefBool __GLEW_ATI_texture_env_combine3 = false;
        internal static RefBool __GLEW_ATI_texture_float = false;
        internal static RefBool __GLEW_ATI_texture_mirror_once = false;
        internal static RefBool __GLEW_ATI_vertex_array_object = false;
        internal static RefBool __GLEW_ATI_vertex_attrib_array_object = false;
        internal static RefBool __GLEW_ATI_vertex_streams = false;
        internal static RefBool __GLEW_DMP_program_binary = false;
        internal static RefBool __GLEW_DMP_shader_binary = false;
        internal static RefBool __GLEW_EXT_422_pixels = false;
        internal static RefBool __GLEW_EXT_Cg_shader = false;
        internal static RefBool __GLEW_EXT_EGL_image_array = false;
        internal static RefBool __GLEW_EXT_EGL_image_external_wrap_modes = false;
        internal static RefBool __GLEW_EXT_EGL_image_storage = false;
        internal static RefBool __GLEW_EXT_EGL_image_storage_compression = false;
        internal static RefBool __GLEW_EXT_EGL_sync = false;
        internal static RefBool __GLEW_EXT_YUV_target = false;
        internal static RefBool __GLEW_EXT_abgr = false;
        internal static RefBool __GLEW_EXT_base_instance = false;
        internal static RefBool __GLEW_EXT_bgra = false;
        internal static RefBool __GLEW_EXT_bindable_uniform = false;
        internal static RefBool __GLEW_EXT_blend_color = false;
        internal static RefBool __GLEW_EXT_blend_equation_separate = false;
        internal static RefBool __GLEW_EXT_blend_func_extended = false;
        internal static RefBool __GLEW_EXT_blend_func_separate = false;
        internal static RefBool __GLEW_EXT_blend_logic_op = false;
        internal static RefBool __GLEW_EXT_blend_minmax = false;
        internal static RefBool __GLEW_EXT_blend_subtract = false;
        internal static RefBool __GLEW_EXT_buffer_storage = false;
        internal static RefBool __GLEW_EXT_clear_texture = false;
        internal static RefBool __GLEW_EXT_clip_control = false;
        internal static RefBool __GLEW_EXT_clip_cull_distance = false;
        internal static RefBool __GLEW_EXT_clip_volume_hint = false;
        internal static RefBool __GLEW_EXT_cmyka = false;
        internal static RefBool __GLEW_EXT_color_buffer_float = false;
        internal static RefBool __GLEW_EXT_color_buffer_half_float = false;
        internal static RefBool __GLEW_EXT_color_subtable = false;
        internal static RefBool __GLEW_EXT_compiled_vertex_array = false;
        internal static RefBool __GLEW_EXT_compressed_ETC1_RGB8_sub_texture = false;
        internal static RefBool __GLEW_EXT_conservative_depth = false;
        internal static RefBool __GLEW_EXT_convolution = false;
        internal static RefBool __GLEW_EXT_coordinate_frame = false;
        internal static RefBool __GLEW_EXT_copy_image = false;
        internal static RefBool __GLEW_EXT_copy_texture = false;
        internal static RefBool __GLEW_EXT_cull_vertex = false;
        internal static RefBool __GLEW_EXT_debug_label = false;
        internal static RefBool __GLEW_EXT_debug_marker = false;
        internal static RefBool __GLEW_EXT_depth_bounds_test = false;
        internal static RefBool __GLEW_EXT_depth_clamp = false;
        internal static RefBool __GLEW_EXT_direct_state_access = false;
        internal static RefBool __GLEW_EXT_discard_framebuffer = false;
        internal static RefBool __GLEW_EXT_disjoint_timer_query = false;
        internal static RefBool __GLEW_EXT_draw_buffers = false;
        internal static RefBool __GLEW_EXT_draw_buffers2 = false;
        internal static RefBool __GLEW_EXT_draw_buffers_indexed = false;
        internal static RefBool __GLEW_EXT_draw_elements_base_vertex = false;
        internal static RefBool __GLEW_EXT_draw_instanced = false;
        internal static RefBool __GLEW_EXT_draw_range_elements = false;
        internal static RefBool __GLEW_EXT_draw_transform_feedback = false;
        internal static RefBool __GLEW_EXT_external_buffer = false;
        internal static RefBool __GLEW_EXT_float_blend = false;
        internal static RefBool __GLEW_EXT_fog_coord = false;
        internal static RefBool __GLEW_EXT_frag_depth = false;
        internal static RefBool __GLEW_EXT_fragment_lighting = false;
        internal static RefBool __GLEW_EXT_fragment_shading_rate = false;
        internal static RefBool __GLEW_EXT_fragment_shading_rate_attachment = false;
        internal static RefBool __GLEW_EXT_fragment_shading_rate_primitive = false;
        internal static RefBool __GLEW_EXT_framebuffer_blit = false;
        internal static RefBool __GLEW_EXT_framebuffer_blit_layers = false;
        internal static RefBool __GLEW_EXT_framebuffer_multisample = false;
        internal static RefBool __GLEW_EXT_framebuffer_multisample_blit_scaled = false;
        internal static RefBool __GLEW_EXT_framebuffer_object = false;
        internal static RefBool __GLEW_EXT_framebuffer_sRGB = false;
        internal static RefBool __GLEW_EXT_geometry_point_size = false;
        internal static RefBool __GLEW_EXT_geometry_shader = false;
        internal static RefBool __GLEW_EXT_geometry_shader4 = false;
        internal static RefBool __GLEW_EXT_gpu_program_parameters = false;
        internal static RefBool __GLEW_EXT_gpu_shader4 = false;
        internal static RefBool __GLEW_EXT_gpu_shader5 = false;
        internal static RefBool __GLEW_EXT_histogram = false;
        internal static RefBool __GLEW_EXT_index_array_formats = false;
        internal static RefBool __GLEW_EXT_index_func = false;
        internal static RefBool __GLEW_EXT_index_material = false;
        internal static RefBool __GLEW_EXT_index_texture = false;
        internal static RefBool __GLEW_EXT_instanced_arrays = false;
        internal static RefBool __GLEW_EXT_light_texture = false;
        internal static RefBool __GLEW_EXT_map_buffer_range = false;
        internal static RefBool __GLEW_EXT_memory_object = false;
        internal static RefBool __GLEW_EXT_memory_object_fd = false;
        internal static RefBool __GLEW_EXT_memory_object_win32 = false;
        internal static RefBool __GLEW_EXT_mesh_shader = false;
        internal static RefBool __GLEW_EXT_misc_attribute = false;
        internal static RefBool __GLEW_EXT_multi_draw_arrays = false;
        internal static RefBool __GLEW_EXT_multi_draw_indirect = false;
        internal static RefBool __GLEW_EXT_multiple_textures = false;
        internal static RefBool __GLEW_EXT_multisample = false;
        internal static RefBool __GLEW_EXT_multisample_compatibility = false;
        internal static RefBool __GLEW_EXT_multisampled_render_to_texture = false;
        internal static RefBool __GLEW_EXT_multisampled_render_to_texture2 = false;
        internal static RefBool __GLEW_EXT_multiview_draw_buffers = false;
        internal static RefBool __GLEW_EXT_multiview_tessellation_geometry_shader = false;
        internal static RefBool __GLEW_EXT_multiview_texture_multisample = false;
        internal static RefBool __GLEW_EXT_multiview_timer_query = false;
        internal static RefBool __GLEW_EXT_occlusion_query_boolean = false;
        internal static RefBool __GLEW_EXT_packed_depth_stencil = false;
        internal static RefBool __GLEW_EXT_packed_float = false;
        internal static RefBool __GLEW_EXT_packed_pixels = false;
        internal static RefBool __GLEW_EXT_paletted_texture = false;
        internal static RefBool __GLEW_EXT_pixel_buffer_object = false;
        internal static RefBool __GLEW_EXT_pixel_transform = false;
        internal static RefBool __GLEW_EXT_pixel_transform_color_table = false;
        internal static RefBool __GLEW_EXT_point_parameters = false;
        internal static RefBool __GLEW_EXT_polygon_offset = false;
        internal static RefBool __GLEW_EXT_polygon_offset_clamp = false;
        internal static RefBool __GLEW_EXT_post_depth_coverage = false;
        internal static RefBool __GLEW_EXT_primitive_bounding_box = false;
        internal static RefBool __GLEW_EXT_protected_textures = false;
        internal static RefBool __GLEW_EXT_provoking_vertex = false;
        internal static RefBool __GLEW_EXT_pvrtc_sRGB = false;
        internal static RefBool __GLEW_EXT_raster_multisample = false;
        internal static RefBool __GLEW_EXT_read_format_bgra = false;
        internal static RefBool __GLEW_EXT_render_snorm = false;
        internal static RefBool __GLEW_EXT_rescale_normal = false;
        internal static RefBool __GLEW_EXT_robustness = false;
        internal static RefBool __GLEW_EXT_sRGB = false;
        internal static RefBool __GLEW_EXT_sRGB_write_control = false;
        internal static RefBool __GLEW_EXT_scene_marker = false;
        internal static RefBool __GLEW_EXT_secondary_color = false;
        internal static RefBool __GLEW_EXT_semaphore = false;
        internal static RefBool __GLEW_EXT_semaphore_fd = false;
        internal static RefBool __GLEW_EXT_semaphore_win32 = false;
        internal static RefBool __GLEW_EXT_separate_depth_stencil = false;
        internal static RefBool __GLEW_EXT_separate_shader_objects = false;
        internal static RefBool __GLEW_EXT_separate_specular_color = false;
        internal static RefBool __GLEW_EXT_shader_clock = false;
        internal static RefBool __GLEW_EXT_shader_framebuffer_fetch = false;
        internal static RefBool __GLEW_EXT_shader_framebuffer_fetch_non_coherent = false;
        internal static RefBool __GLEW_EXT_shader_group_vote = false;
        internal static RefBool __GLEW_EXT_shader_image_load_formatted = false;
        internal static RefBool __GLEW_EXT_shader_image_load_store = false;
        internal static RefBool __GLEW_EXT_shader_implicit_conversions = false;
        internal static RefBool __GLEW_EXT_shader_integer_mix = false;
        internal static RefBool __GLEW_EXT_shader_io_blocks = false;
        internal static RefBool __GLEW_EXT_shader_non_constant_global_initializers = false;
        internal static RefBool __GLEW_EXT_shader_pixel_local_storage = false;
        internal static RefBool __GLEW_EXT_shader_pixel_local_storage2 = false;
        internal static RefBool __GLEW_EXT_shader_realtime_clock = false;
        internal static RefBool __GLEW_EXT_shader_samples_identical = false;
        internal static RefBool __GLEW_EXT_shader_texture_lod = false;
        internal static RefBool __GLEW_EXT_shader_texture_samples = false;
        internal static RefBool __GLEW_EXT_shadow_funcs = false;
        internal static RefBool __GLEW_EXT_shadow_samplers = false;
        internal static RefBool __GLEW_EXT_shared_texture_palette = false;
        internal static RefBool __GLEW_EXT_sparse_texture = false;
        internal static RefBool __GLEW_EXT_sparse_texture2 = false;
        internal static RefBool __GLEW_EXT_static_vertex_array = false;
        internal static RefBool __GLEW_EXT_stencil_clear_tag = false;
        internal static RefBool __GLEW_EXT_stencil_two_side = false;
        internal static RefBool __GLEW_EXT_stencil_wrap = false;
        internal static RefBool __GLEW_EXT_subtexture = false;
        internal static RefBool __GLEW_EXT_tessellation_point_size = false;
        internal static RefBool __GLEW_EXT_tessellation_shader = false;
        internal static RefBool __GLEW_EXT_texture = false;
        internal static RefBool __GLEW_EXT_texture3D = false;
        internal static RefBool __GLEW_EXT_texture_array = false;
        internal static RefBool __GLEW_EXT_texture_border_clamp = false;
        internal static RefBool __GLEW_EXT_texture_buffer = false;
        internal static RefBool __GLEW_EXT_texture_buffer_object = false;
        internal static RefBool __GLEW_EXT_texture_compression_astc_decode_mode = false;
        internal static RefBool __GLEW_EXT_texture_compression_astc_decode_mode_rgb9e5 = false;
        internal static RefBool __GLEW_EXT_texture_compression_bptc = false;
        internal static RefBool __GLEW_EXT_texture_compression_dxt1 = false;
        internal static RefBool __GLEW_EXT_texture_compression_latc = false;
        internal static RefBool __GLEW_EXT_texture_compression_rgtc = false;
        internal static RefBool __GLEW_EXT_texture_compression_s3tc = false;
        internal static RefBool __GLEW_EXT_texture_compression_s3tc_srgb = false;
        internal static RefBool __GLEW_EXT_texture_cube_map = false;
        internal static RefBool __GLEW_EXT_texture_cube_map_array = false;
        internal static RefBool __GLEW_EXT_texture_edge_clamp = false;
        internal static RefBool __GLEW_EXT_texture_env = false;
        internal static RefBool __GLEW_EXT_texture_env_add = false;
        internal static RefBool __GLEW_EXT_texture_env_combine = false;
        internal static RefBool __GLEW_EXT_texture_env_dot3 = false;
        internal static RefBool __GLEW_EXT_texture_filter_anisotropic = false;
        internal static RefBool __GLEW_EXT_texture_filter_minmax = false;
        internal static RefBool __GLEW_EXT_texture_format_BGRA8888 = false;
        internal static RefBool __GLEW_EXT_texture_format_sRGB_override = false;
        internal static RefBool __GLEW_EXT_texture_integer = false;
        internal static RefBool __GLEW_EXT_texture_lod_bias = false;
        internal static RefBool __GLEW_EXT_texture_mirror_clamp = false;
        internal static RefBool __GLEW_EXT_texture_mirror_clamp_to_edge = false;
        internal static RefBool __GLEW_EXT_texture_norm16 = false;
        internal static RefBool __GLEW_EXT_texture_object = false;
        internal static RefBool __GLEW_EXT_texture_perturb_normal = false;
        internal static RefBool __GLEW_EXT_texture_query_lod = false;
        internal static RefBool __GLEW_EXT_texture_rectangle = false;
        internal static RefBool __GLEW_EXT_texture_rg = false;
        internal static RefBool __GLEW_EXT_texture_sRGB = false;
        internal static RefBool __GLEW_EXT_texture_sRGB_R8 = false;
        internal static RefBool __GLEW_EXT_texture_sRGB_RG8 = false;
        internal static RefBool __GLEW_EXT_texture_sRGB_decode = false;
        internal static RefBool __GLEW_EXT_texture_shadow_lod = false;
        internal static RefBool __GLEW_EXT_texture_shared_exponent = false;
        internal static RefBool __GLEW_EXT_texture_snorm = false;
        internal static RefBool __GLEW_EXT_texture_storage = false;
        internal static RefBool __GLEW_EXT_texture_storage_compression = false;
        internal static RefBool __GLEW_EXT_texture_swizzle = false;
        internal static RefBool __GLEW_EXT_texture_type_2_10_10_10_REV = false;
        internal static RefBool __GLEW_EXT_texture_view = false;
        internal static RefBool __GLEW_EXT_timer_query = false;
        internal static RefBool __GLEW_EXT_transform_feedback = false;
        internal static RefBool __GLEW_EXT_unpack_subimage = false;
        internal static RefBool __GLEW_EXT_vertex_array = false;
        internal static RefBool __GLEW_EXT_vertex_array_bgra = false;
        internal static RefBool __GLEW_EXT_vertex_array_setXXX = false;
        internal static RefBool __GLEW_EXT_vertex_attrib_64bit = false;
        internal static RefBool __GLEW_EXT_vertex_shader = false;
        internal static RefBool __GLEW_EXT_vertex_weighting = false;
        internal static RefBool __GLEW_EXT_win32_keyed_mutex = false;
        internal static RefBool __GLEW_EXT_window_rectangles = false;
        internal static RefBool __GLEW_EXT_x11_sync_object = false;
        internal static RefBool __GLEW_FJ_shader_binary_GCCSO = false;
        internal static RefBool __GLEW_GREMEDY_frame_terminator = false;
        internal static RefBool __GLEW_GREMEDY_string_marker = false;
        internal static RefBool __GLEW_HP_convolution_border_modes = false;
        internal static RefBool __GLEW_HP_image_transform = false;
        internal static RefBool __GLEW_HP_occlusion_test = false;
        internal static RefBool __GLEW_HP_texture_lighting = false;
        internal static RefBool __GLEW_HUAWEI_program_binary = false;
        internal static RefBool __GLEW_HUAWEI_shader_binary = false;
        internal static RefBool __GLEW_IBM_cull_vertex = false;
        internal static RefBool __GLEW_IBM_multimode_draw_arrays = false;
        internal static RefBool __GLEW_IBM_rasterpos_clip = false;
        internal static RefBool __GLEW_IBM_static_data = false;
        internal static RefBool __GLEW_IBM_texture_mirrored_repeat = false;
        internal static RefBool __GLEW_IBM_vertex_array_lists = false;
        internal static RefBool __GLEW_IMG_bindless_texture = false;
        internal static RefBool __GLEW_IMG_framebuffer_downsample = false;
        internal static RefBool __GLEW_IMG_multisampled_render_to_texture = false;
        internal static RefBool __GLEW_IMG_program_binary = false;
        internal static RefBool __GLEW_IMG_pvric_end_to_end_signature = false;
        internal static RefBool __GLEW_IMG_read_format = false;
        internal static RefBool __GLEW_IMG_shader_binary = false;
        internal static RefBool __GLEW_IMG_texture_compression_pvrtc = false;
        internal static RefBool __GLEW_IMG_texture_compression_pvrtc2 = false;
        internal static RefBool __GLEW_IMG_texture_env_enhanced_fixed_function = false;
        internal static RefBool __GLEW_IMG_texture_filter_cubic = false;
        internal static RefBool __GLEW_IMG_tile_region_protection = false;
        internal static RefBool __GLEW_INGR_color_clamp = false;
        internal static RefBool __GLEW_INGR_interlace_read = false;
        internal static RefBool __GLEW_INTEL_blackhole_render = false;
        internal static RefBool __GLEW_INTEL_conservative_rasterization = false;
        internal static RefBool __GLEW_INTEL_fragment_shader_ordering = false;
        internal static RefBool __GLEW_INTEL_framebuffer_CMAA = false;
        internal static RefBool __GLEW_INTEL_map_texture = false;
        internal static RefBool __GLEW_INTEL_parallel_arrays = false;
        internal static RefBool __GLEW_INTEL_performance_query = false;
        internal static RefBool __GLEW_INTEL_shader_integer_functions2 = false;
        internal static RefBool __GLEW_INTEL_texture_scissor = false;
        internal static RefBool __GLEW_KHR_blend_equation_advanced = false;
        internal static RefBool __GLEW_KHR_blend_equation_advanced_coherent = false;
        internal static RefBool __GLEW_KHR_context_flush_control = false;
        internal static RefBool __GLEW_KHR_debug = false;
        internal static RefBool __GLEW_KHR_no_error = false;
        internal static RefBool __GLEW_KHR_parallel_shader_compile = false;
        internal static RefBool __GLEW_KHR_robust_buffer_access_behavior = false;
        internal static RefBool __GLEW_KHR_robustness = false;
        internal static RefBool __GLEW_KHR_shader_subgroup = false;
        internal static RefBool __GLEW_KHR_texture_compression_astc_hdr = false;
        internal static RefBool __GLEW_KHR_texture_compression_astc_ldr = false;
        internal static RefBool __GLEW_KHR_texture_compression_astc_sliced_3d = false;
        internal static RefBool __GLEW_KTX_buffer_region = false;
        internal static RefBool __GLEW_MESAX_texture_stack = false;
        internal static RefBool __GLEW_MESA_bgra = false;
        internal static RefBool __GLEW_MESA_framebuffer_flip_x = false;
        internal static RefBool __GLEW_MESA_framebuffer_flip_y = false;
        internal static RefBool __GLEW_MESA_framebuffer_swap_xy = false;
        internal static RefBool __GLEW_MESA_pack_invert = false;
        internal static RefBool __GLEW_MESA_program_binary_formats = false;
        internal static RefBool __GLEW_MESA_resize_buffers = false;
        internal static RefBool __GLEW_MESA_shader_integer_functions = false;
        internal static RefBool __GLEW_MESA_texture_const_bandwidth = false;
        internal static RefBool __GLEW_MESA_tile_raster_order = false;
        internal static RefBool __GLEW_MESA_window_pos = false;
        internal static RefBool __GLEW_MESA_ycbcr_texture = false;
        internal static RefBool __GLEW_NVX_blend_equation_advanced_multi_draw_buffers = false;
        internal static RefBool __GLEW_NVX_conditional_render = false;
        internal static RefBool __GLEW_NVX_gpu_memory_info = false;
        internal static RefBool __GLEW_NVX_gpu_multicast2 = false;
        internal static RefBool __GLEW_NVX_linked_gpu_multicast = false;
        internal static RefBool __GLEW_NVX_progress_fence = false;
        internal static RefBool __GLEW_NV_3dvision_settings = false;
        internal static RefBool __GLEW_NV_EGL_stream_consumer_external = false;
        internal static RefBool __GLEW_NV_alpha_to_coverage_dither_control = false;
        internal static RefBool __GLEW_NV_bgr = false;
        internal static RefBool __GLEW_NV_bindless_multi_draw_indirect = false;
        internal static RefBool __GLEW_NV_bindless_multi_draw_indirect_count = false;
        internal static RefBool __GLEW_NV_bindless_texture = false;
        internal static RefBool __GLEW_NV_blend_equation_advanced = false;
        internal static RefBool __GLEW_NV_blend_equation_advanced_coherent = false;
        internal static RefBool __GLEW_NV_blend_minmax_factor = false;
        internal static RefBool __GLEW_NV_blend_square = false;
        internal static RefBool __GLEW_NV_clip_space_w_scaling = false;
        internal static RefBool __GLEW_NV_command_list = false;
        internal static RefBool __GLEW_NV_compute_program5 = false;
        internal static RefBool __GLEW_NV_compute_shader_derivatives = false;
        internal static RefBool __GLEW_NV_conditional_render = false;
        internal static RefBool __GLEW_NV_conservative_raster = false;
        internal static RefBool __GLEW_NV_conservative_raster_dilate = false;
        internal static RefBool __GLEW_NV_conservative_raster_pre_snap = false;
        internal static RefBool __GLEW_NV_conservative_raster_pre_snap_triangles = false;
        internal static RefBool __GLEW_NV_conservative_raster_underestimation = false;
        internal static RefBool __GLEW_NV_copy_buffer = false;
        internal static RefBool __GLEW_NV_copy_depth_to_color = false;
        internal static RefBool __GLEW_NV_copy_image = false;
        internal static RefBool __GLEW_NV_deep_texture3D = false;
        internal static RefBool __GLEW_NV_depth_buffer_float = false;
        internal static RefBool __GLEW_NV_depth_clamp = false;
        internal static RefBool __GLEW_NV_depth_nonlinear = false;
        internal static RefBool __GLEW_NV_depth_range_unclamped = false;
        internal static RefBool __GLEW_NV_draw_buffers = false;
        internal static RefBool __GLEW_NV_draw_instanced = false;
        internal static RefBool __GLEW_NV_draw_texture = false;
        internal static RefBool __GLEW_NV_draw_vulkan_image = false;
        internal static RefBool __GLEW_NV_evaluators = false;
        internal static RefBool __GLEW_NV_explicit_attrib_location = false;
        internal static RefBool __GLEW_NV_explicit_multisample = false;
        internal static RefBool __GLEW_NV_fbo_color_attachments = false;
        internal static RefBool __GLEW_NV_fence = false;
        internal static RefBool __GLEW_NV_fill_rectangle = false;
        internal static RefBool __GLEW_NV_float_buffer = false;
        internal static RefBool __GLEW_NV_fog_distance = false;
        internal static RefBool __GLEW_NV_fragment_coverage_to_color = false;
        internal static RefBool __GLEW_NV_fragment_program = false;
        internal static RefBool __GLEW_NV_fragment_program2 = false;
        internal static RefBool __GLEW_NV_fragment_program4 = false;
        internal static RefBool __GLEW_NV_fragment_program_option = false;
        internal static RefBool __GLEW_NV_fragment_shader_barycentric = false;
        internal static RefBool __GLEW_NV_fragment_shader_interlock = false;
        internal static RefBool __GLEW_NV_framebuffer_blit = false;
        internal static RefBool __GLEW_NV_framebuffer_mixed_samples = false;
        internal static RefBool __GLEW_NV_framebuffer_multisample = false;
        internal static RefBool __GLEW_NV_framebuffer_multisample_coverage = false;
        internal static RefBool __GLEW_NV_generate_mipmap_sRGB = false;
        internal static RefBool __GLEW_NV_geometry_program4 = false;
        internal static RefBool __GLEW_NV_geometry_shader4 = false;
        internal static RefBool __GLEW_NV_geometry_shader_passthrough = false;
        internal static RefBool __GLEW_NV_gpu_multicast = false;
        internal static RefBool __GLEW_NV_gpu_program4 = false;
        internal static RefBool __GLEW_NV_gpu_program5 = false;
        internal static RefBool __GLEW_NV_gpu_program5_mem_extended = false;
        internal static RefBool __GLEW_NV_gpu_program_fp64 = false;
        internal static RefBool __GLEW_NV_gpu_shader5 = false;
        internal static RefBool __GLEW_NV_half_float = false;
        internal static RefBool __GLEW_NV_image_formats = false;
        internal static RefBool __GLEW_NV_instanced_arrays = false;
        internal static RefBool __GLEW_NV_internalformat_sample_query = false;
        internal static RefBool __GLEW_NV_light_max_exponent = false;
        internal static RefBool __GLEW_NV_memory_attachment = false;
        internal static RefBool __GLEW_NV_memory_object_sparse = false;
        internal static RefBool __GLEW_NV_mesh_shader = false;
        internal static RefBool __GLEW_NV_multisample_coverage = false;
        internal static RefBool __GLEW_NV_multisample_filter_hint = false;
        internal static RefBool __GLEW_NV_non_square_matrices = false;
        internal static RefBool __GLEW_NV_occlusion_query = false;
        internal static RefBool __GLEW_NV_pack_subimage = false;
        internal static RefBool __GLEW_NV_packed_depth_stencil = false;
        internal static RefBool __GLEW_NV_packed_float = false;
        internal static RefBool __GLEW_NV_packed_float_linear = false;
        internal static RefBool __GLEW_NV_parameter_buffer_object = false;
        internal static RefBool __GLEW_NV_parameter_buffer_object2 = false;
        internal static RefBool __GLEW_NV_path_rendering = false;
        internal static RefBool __GLEW_NV_path_rendering_shared_edge = false;
        internal static RefBool __GLEW_NV_pixel_buffer_object = false;
        internal static RefBool __GLEW_NV_pixel_data_range = false;
        internal static RefBool __GLEW_NV_platform_binary = false;
        internal static RefBool __GLEW_NV_point_sprite = false;
        internal static RefBool __GLEW_NV_polygon_mode = false;
        internal static RefBool __GLEW_NV_present_video = false;
        internal static RefBool __GLEW_NV_primitive_restart = false;
        internal static RefBool __GLEW_NV_primitive_shading_rate = false;
        internal static RefBool __GLEW_NV_query_resource_tag = false;
        internal static RefBool __GLEW_NV_read_buffer = false;
        internal static RefBool __GLEW_NV_read_buffer_front = false;
        internal static RefBool __GLEW_NV_read_depth = false;
        internal static RefBool __GLEW_NV_read_depth_stencil = false;
        internal static RefBool __GLEW_NV_read_stencil = false;
        internal static RefBool __GLEW_NV_register_combiners = false;
        internal static RefBool __GLEW_NV_register_combiners2 = false;
        internal static RefBool __GLEW_NV_representative_fragment_test = false;
        internal static RefBool __GLEW_NV_robustness_video_memory_purge = false;
        internal static RefBool __GLEW_NV_sRGB_formats = false;
        internal static RefBool __GLEW_NV_sample_locations = false;
        internal static RefBool __GLEW_NV_sample_mask_override_coverage = false;
        internal static RefBool __GLEW_NV_scissor_exclusive = false;
        internal static RefBool __GLEW_NV_shader_atomic_counters = false;
        internal static RefBool __GLEW_NV_shader_atomic_float = false;
        internal static RefBool __GLEW_NV_shader_atomic_float64 = false;
        internal static RefBool __GLEW_NV_shader_atomic_fp16_vector = false;
        internal static RefBool __GLEW_NV_shader_atomic_int64 = false;
        internal static RefBool __GLEW_NV_shader_buffer_load = false;
        internal static RefBool __GLEW_NV_shader_noperspective_interpolation = false;
        internal static RefBool __GLEW_NV_shader_storage_buffer_object = false;
        internal static RefBool __GLEW_NV_shader_subgroup_partitioned = false;
        internal static RefBool __GLEW_NV_shader_texture_footprint = false;
        internal static RefBool __GLEW_NV_shader_thread_group = false;
        internal static RefBool __GLEW_NV_shader_thread_shuffle = false;
        internal static RefBool __GLEW_NV_shading_rate_image = false;
        internal static RefBool __GLEW_NV_shadow_samplers_array = false;
        internal static RefBool __GLEW_NV_shadow_samplers_cube = false;
        internal static RefBool __GLEW_NV_stereo_view_rendering = false;
        internal static RefBool __GLEW_NV_tessellation_program5 = false;
        internal static RefBool __GLEW_NV_texgen_emboss = false;
        internal static RefBool __GLEW_NV_texgen_reflection = false;
        internal static RefBool __GLEW_NV_texture_array = false;
        internal static RefBool __GLEW_NV_texture_barrier = false;
        internal static RefBool __GLEW_NV_texture_border_clamp = false;
        internal static RefBool __GLEW_NV_texture_compression_latc = false;
        internal static RefBool __GLEW_NV_texture_compression_s3tc = false;
        internal static RefBool __GLEW_NV_texture_compression_s3tc_update = false;
        internal static RefBool __GLEW_NV_texture_compression_vtc = false;
        internal static RefBool __GLEW_NV_texture_env_combine4 = false;
        internal static RefBool __GLEW_NV_texture_expand_normal = false;
        internal static RefBool __GLEW_NV_texture_multisample = false;
        internal static RefBool __GLEW_NV_texture_npot_2D_mipmap = false;
        internal static RefBool __GLEW_NV_texture_rectangle = false;
        internal static RefBool __GLEW_NV_texture_rectangle_compressed = false;
        internal static RefBool __GLEW_NV_texture_shader = false;
        internal static RefBool __GLEW_NV_texture_shader2 = false;
        internal static RefBool __GLEW_NV_texture_shader3 = false;
        internal static RefBool __GLEW_NV_timeline_semaphore = false;
        internal static RefBool __GLEW_NV_transform_feedback = false;
        internal static RefBool __GLEW_NV_transform_feedback2 = false;
        internal static RefBool __GLEW_NV_uniform_buffer_std430_layout = false;
        internal static RefBool __GLEW_NV_uniform_buffer_unified_memory = false;
        internal static RefBool __GLEW_NV_vdpau_interop = false;
        internal static RefBool __GLEW_NV_vdpau_interop2 = false;
        internal static RefBool __GLEW_NV_vertex_array_range = false;
        internal static RefBool __GLEW_NV_vertex_array_range2 = false;
        internal static RefBool __GLEW_NV_vertex_attrib_integer_64bit = false;
        internal static RefBool __GLEW_NV_vertex_buffer_unified_memory = false;
        internal static RefBool __GLEW_NV_vertex_program = false;
        internal static RefBool __GLEW_NV_vertex_program1_1 = false;
        internal static RefBool __GLEW_NV_vertex_program2 = false;
        internal static RefBool __GLEW_NV_vertex_program2_option = false;
        internal static RefBool __GLEW_NV_vertex_program3 = false;
        internal static RefBool __GLEW_NV_vertex_program4 = false;
        internal static RefBool __GLEW_NV_video_capture = false;
        internal static RefBool __GLEW_NV_viewport_array = false;
        internal static RefBool __GLEW_NV_viewport_array2 = false;
        internal static RefBool __GLEW_NV_viewport_swizzle = false;
        internal static RefBool __GLEW_OES_EGL_image = false;
        internal static RefBool __GLEW_OES_EGL_image_external = false;
        internal static RefBool __GLEW_OES_EGL_image_external_essl3 = false;
        internal static RefBool __GLEW_OES_blend_equation_separate = false;
        internal static RefBool __GLEW_OES_blend_func_separate = false;
        internal static RefBool __GLEW_OES_blend_subtract = false;
        internal static RefBool __GLEW_OES_byte_coordinates = false;
        internal static RefBool __GLEW_OES_compressed_ETC1_RGB8_texture = false;
        internal static RefBool __GLEW_OES_compressed_paletted_texture = false;
        internal static RefBool __GLEW_OES_copy_image = false;
        internal static RefBool __GLEW_OES_depth24 = false;
        internal static RefBool __GLEW_OES_depth32 = false;
        internal static RefBool __GLEW_OES_depth_texture = false;
        internal static RefBool __GLEW_OES_depth_texture_cube_map = false;
        internal static RefBool __GLEW_OES_draw_buffers_indexed = false;
        internal static RefBool __GLEW_OES_draw_texture = false;
        internal static RefBool __GLEW_OES_element_index_uint = false;
        internal static RefBool __GLEW_OES_extended_matrix_palette = false;
        internal static RefBool __GLEW_OES_fbo_render_mipmap = false;
        internal static RefBool __GLEW_OES_fragment_precision_high = false;
        internal static RefBool __GLEW_OES_framebuffer_object = false;
        internal static RefBool __GLEW_OES_geometry_point_size = false;
        internal static RefBool __GLEW_OES_geometry_shader = false;
        internal static RefBool __GLEW_OES_get_program_binary = false;
        internal static RefBool __GLEW_OES_gpu_shader5 = false;
        internal static RefBool __GLEW_OES_mapbuffer = false;
        internal static RefBool __GLEW_OES_matrix_get = false;
        internal static RefBool __GLEW_OES_matrix_palette = false;
        internal static RefBool __GLEW_OES_packed_depth_stencil = false;
        internal static RefBool __GLEW_OES_point_size_array = false;
        internal static RefBool __GLEW_OES_point_sprite = false;
        internal static RefBool __GLEW_OES_read_format = false;
        internal static RefBool __GLEW_OES_required_internalformat = false;
        internal static RefBool __GLEW_OES_rgb8_rgba8 = false;
        internal static RefBool __GLEW_OES_sample_shading = false;
        internal static RefBool __GLEW_OES_sample_variables = false;
        internal static RefBool __GLEW_OES_shader_image_atomic = false;
        internal static RefBool __GLEW_OES_shader_io_blocks = false;
        internal static RefBool __GLEW_OES_shader_multisample_interpolation = false;
        internal static RefBool __GLEW_OES_single_precision = false;
        internal static RefBool __GLEW_OES_standard_derivatives = false;
        internal static RefBool __GLEW_OES_stencil1 = false;
        internal static RefBool __GLEW_OES_stencil4 = false;
        internal static RefBool __GLEW_OES_stencil8 = false;
        internal static RefBool __GLEW_OES_surfaceless_context = false;
        internal static RefBool __GLEW_OES_tessellation_point_size = false;
        internal static RefBool __GLEW_OES_tessellation_shader = false;
        internal static RefBool __GLEW_OES_texture_3D = false;
        internal static RefBool __GLEW_OES_texture_border_clamp = false;
        internal static RefBool __GLEW_OES_texture_buffer = false;
        internal static RefBool __GLEW_OES_texture_compression_astc = false;
        internal static RefBool __GLEW_OES_texture_cube_map = false;
        internal static RefBool __GLEW_OES_texture_cube_map_array = false;
        internal static RefBool __GLEW_OES_texture_env_crossbar = false;
        internal static RefBool __GLEW_OES_texture_mirrored_repeat = false;
        internal static RefBool __GLEW_OES_texture_npot = false;
        internal static RefBool __GLEW_OES_texture_stencil8 = false;
        internal static RefBool __GLEW_OES_texture_storage_multisample_2d_array = false;
        internal static RefBool __GLEW_OES_texture_view = false;
        internal static RefBool __GLEW_OES_vertex_array_object = false;
        internal static RefBool __GLEW_OES_vertex_half_float = false;
        internal static RefBool __GLEW_OES_vertex_type_10_10_10_2 = false;
        internal static RefBool __GLEW_OML_interlace = false;
        internal static RefBool __GLEW_OML_resample = false;
        internal static RefBool __GLEW_OML_subsample = false;
        internal static RefBool __GLEW_OVR_multiview = false;
        internal static RefBool __GLEW_OVR_multiview2 = false;
        internal static RefBool __GLEW_OVR_multiview_multisampled_render_to_texture = false;
        internal static RefBool __GLEW_PGI_misc_hints = false;
        internal static RefBool __GLEW_PGI_vertex_hints = false;
        internal static RefBool __GLEW_QCOM_YUV_texture_gather = false;
        internal static RefBool __GLEW_QCOM_alpha_test = false;
        internal static RefBool __GLEW_QCOM_binning_control = false;
        internal static RefBool __GLEW_QCOM_driver_control = false;
        internal static RefBool __GLEW_QCOM_extended_get = false;
        internal static RefBool __GLEW_QCOM_extended_get2 = false;
        internal static RefBool __GLEW_QCOM_frame_extrapolation = false;
        internal static RefBool __GLEW_QCOM_framebuffer_foveated = false;
        internal static RefBool __GLEW_QCOM_motion_estimation = false;
        internal static RefBool __GLEW_QCOM_perfmon_global_mode = false;
        internal static RefBool __GLEW_QCOM_render_sRGB_R8_RG8 = false;
        internal static RefBool __GLEW_QCOM_render_shared_exponent = false;
        internal static RefBool __GLEW_QCOM_shader_framebuffer_fetch_noncoherent = false;
        internal static RefBool __GLEW_QCOM_shader_framebuffer_fetch_rate = false;
        internal static RefBool __GLEW_QCOM_shading_rate = false;
        internal static RefBool __GLEW_QCOM_texture_foveated = false;
        internal static RefBool __GLEW_QCOM_texture_foveated2 = false;
        internal static RefBool __GLEW_QCOM_texture_foveated_subsampled_layout = false;
        internal static RefBool __GLEW_QCOM_texture_lod_bias = false;
        internal static RefBool __GLEW_QCOM_tiled_rendering = false;
        internal static RefBool __GLEW_QCOM_writeonly_rendering = false;
        internal static RefBool __GLEW_QCOM_ycbcr_degamma = false;
        internal static RefBool __GLEW_REGAL_ES1_0_compatibility = false;
        internal static RefBool __GLEW_REGAL_ES1_1_compatibility = false;
        internal static RefBool __GLEW_REGAL_enable = false;
        internal static RefBool __GLEW_REGAL_error_string = false;
        internal static RefBool __GLEW_REGAL_extension_query = false;
        internal static RefBool __GLEW_REGAL_log = false;
        internal static RefBool __GLEW_REGAL_proc_address = false;
        internal static RefBool __GLEW_REND_screen_coordinates = false;
        internal static RefBool __GLEW_S3_s3tc = false;
        internal static RefBool __GLEW_SGIS_clip_band_hint = false;
        internal static RefBool __GLEW_SGIS_color_range = false;
        internal static RefBool __GLEW_SGIS_detail_texture = false;
        internal static RefBool __GLEW_SGIS_fog_function = false;
        internal static RefBool __GLEW_SGIS_generate_mipmap = false;
        internal static RefBool __GLEW_SGIS_line_texgen = false;
        internal static RefBool __GLEW_SGIS_multisample = false;
        internal static RefBool __GLEW_SGIS_multitexture = false;
        internal static RefBool __GLEW_SGIS_pixel_texture = false;
        internal static RefBool __GLEW_SGIS_point_line_texgen = false;
        internal static RefBool __GLEW_SGIS_shared_multisample = false;
        internal static RefBool __GLEW_SGIS_sharpen_texture = false;
        internal static RefBool __GLEW_SGIS_texture4D = false;
        internal static RefBool __GLEW_SGIS_texture_border_clamp = false;
        internal static RefBool __GLEW_SGIS_texture_edge_clamp = false;
        internal static RefBool __GLEW_SGIS_texture_filter4 = false;
        internal static RefBool __GLEW_SGIS_texture_lod = false;
        internal static RefBool __GLEW_SGIS_texture_select = false;
        internal static RefBool __GLEW_SGIX_async = false;
        internal static RefBool __GLEW_SGIX_async_histogram = false;
        internal static RefBool __GLEW_SGIX_async_pixel = false;
        internal static RefBool __GLEW_SGIX_bali_g_instruments = false;
        internal static RefBool __GLEW_SGIX_bali_r_instruments = false;
        internal static RefBool __GLEW_SGIX_bali_timer_instruments = false;
        internal static RefBool __GLEW_SGIX_blend_alpha_minmax = false;
        internal static RefBool __GLEW_SGIX_blend_cadd = false;
        internal static RefBool __GLEW_SGIX_blend_cmultiply = false;
        internal static RefBool __GLEW_SGIX_calligraphic_fragment = false;
        internal static RefBool __GLEW_SGIX_clipmap = false;
        internal static RefBool __GLEW_SGIX_color_matrix_accuracy = false;
        internal static RefBool __GLEW_SGIX_color_table_index_mode = false;
        internal static RefBool __GLEW_SGIX_complex_polar = false;
        internal static RefBool __GLEW_SGIX_convolution_accuracy = false;
        internal static RefBool __GLEW_SGIX_cube_map = false;
        internal static RefBool __GLEW_SGIX_cylinder_texgen = false;
        internal static RefBool __GLEW_SGIX_datapipe = false;
        internal static RefBool __GLEW_SGIX_decimation = false;
        internal static RefBool __GLEW_SGIX_depth_pass_instrument = false;
        internal static RefBool __GLEW_SGIX_depth_texture = false;
        internal static RefBool __GLEW_SGIX_dvc = false;
        internal static RefBool __GLEW_SGIX_flush_raster = false;
        internal static RefBool __GLEW_SGIX_fog_blend = false;
        internal static RefBool __GLEW_SGIX_fog_factor_to_alpha = false;
        internal static RefBool __GLEW_SGIX_fog_layers = false;
        internal static RefBool __GLEW_SGIX_fog_offset = false;
        internal static RefBool __GLEW_SGIX_fog_patchy = false;
        internal static RefBool __GLEW_SGIX_fog_scale = false;
        internal static RefBool __GLEW_SGIX_fog_texture = false;
        internal static RefBool __GLEW_SGIX_fragment_lighting_space = false;
        internal static RefBool __GLEW_SGIX_fragment_specular_lighting = false;
        internal static RefBool __GLEW_SGIX_fragments_instrument = false;
        internal static RefBool __GLEW_SGIX_framezoom = false;
        internal static RefBool __GLEW_SGIX_icc_texture = false;
        internal static RefBool __GLEW_SGIX_igloo_interface = false;
        internal static RefBool __GLEW_SGIX_image_compression = false;
        internal static RefBool __GLEW_SGIX_impact_pixel_texture = false;
        internal static RefBool __GLEW_SGIX_instrument_error = false;
        internal static RefBool __GLEW_SGIX_interlace = false;
        internal static RefBool __GLEW_SGIX_ir_instrument1 = false;
        internal static RefBool __GLEW_SGIX_line_quality_hint = false;
        internal static RefBool __GLEW_SGIX_list_priority = false;
        internal static RefBool __GLEW_SGIX_mpeg1 = false;
        internal static RefBool __GLEW_SGIX_mpeg2 = false;
        internal static RefBool __GLEW_SGIX_nonlinear_lighting_pervertex = false;
        internal static RefBool __GLEW_SGIX_nurbs_eval = false;
        internal static RefBool __GLEW_SGIX_occlusion_instrument = false;
        internal static RefBool __GLEW_SGIX_packed_6bytes = false;
        internal static RefBool __GLEW_SGIX_pixel_texture = false;
        internal static RefBool __GLEW_SGIX_pixel_texture_bits = false;
        internal static RefBool __GLEW_SGIX_pixel_texture_lod = false;
        internal static RefBool __GLEW_SGIX_pixel_tiles = false;
        internal static RefBool __GLEW_SGIX_polynomial_ffd = false;
        internal static RefBool __GLEW_SGIX_quad_mesh = false;
        internal static RefBool __GLEW_SGIX_reference_plane = false;
        internal static RefBool __GLEW_SGIX_resample = false;
        internal static RefBool __GLEW_SGIX_scalebias_hint = false;
        internal static RefBool __GLEW_SGIX_shadow = false;
        internal static RefBool __GLEW_SGIX_shadow_ambient = false;
        internal static RefBool __GLEW_SGIX_slim = false;
        internal static RefBool __GLEW_SGIX_spotlight_cutoff = false;
        internal static RefBool __GLEW_SGIX_sprite = false;
        internal static RefBool __GLEW_SGIX_subdiv_patch = false;
        internal static RefBool __GLEW_SGIX_subsample = false;
        internal static RefBool __GLEW_SGIX_tag_sample_buffer = false;
        internal static RefBool __GLEW_SGIX_texture_add_env = false;
        internal static RefBool __GLEW_SGIX_texture_coordinate_clamp = false;
        internal static RefBool __GLEW_SGIX_texture_lod_bias = false;
        internal static RefBool __GLEW_SGIX_texture_mipmap_anisotropic = false;
        internal static RefBool __GLEW_SGIX_texture_multi_buffer = false;
        internal static RefBool __GLEW_SGIX_texture_phase = false;
        internal static RefBool __GLEW_SGIX_texture_range = false;
        internal static RefBool __GLEW_SGIX_texture_scale_bias = false;
        internal static RefBool __GLEW_SGIX_texture_supersample = false;
        internal static RefBool __GLEW_SGIX_vector_ops = false;
        internal static RefBool __GLEW_SGIX_vertex_array_object = false;
        internal static RefBool __GLEW_SGIX_vertex_preclip = false;
        internal static RefBool __GLEW_SGIX_vertex_preclip_hint = false;
        internal static RefBool __GLEW_SGIX_ycrcb = false;
        internal static RefBool __GLEW_SGIX_ycrcb_subsample = false;
        internal static RefBool __GLEW_SGIX_ycrcba = false;
        internal static RefBool __GLEW_SGI_color_matrix = false;
        internal static RefBool __GLEW_SGI_color_table = false;
        internal static RefBool __GLEW_SGI_complex = false;
        internal static RefBool __GLEW_SGI_complex_type = false;
        internal static RefBool __GLEW_SGI_fft = false;
        internal static RefBool __GLEW_SGI_texture_color_table = false;
        internal static RefBool __GLEW_SUNX_constant_data = false;
        internal static RefBool __GLEW_SUN_convolution_border_modes = false;
        internal static RefBool __GLEW_SUN_global_alpha = false;
        internal static RefBool __GLEW_SUN_mesh_array = false;
        internal static RefBool __GLEW_SUN_read_video_pixels = false;
        internal static RefBool __GLEW_SUN_slice_accum = false;
        internal static RefBool __GLEW_SUN_triangle_list = false;
        internal static RefBool __GLEW_SUN_vertex = false;
        internal static RefBool __GLEW_VIV_shader_binary = false;
        internal static RefBool __GLEW_WIN_phong_shading = false;
        internal static RefBool __GLEW_WIN_scene_markerXXX = false;
        internal static RefBool __GLEW_WIN_specular_fog = false;
        internal static RefBool __GLEW_WIN_swap_hint = false;
        #endregion

        internal static string[] _glewExtensionLookup = {
#if GL_3DFX_multisample
  "GL_3DFX_multisample",
#endif
#if GL_3DFX_tbuffer
  "GL_3DFX_tbuffer",
#endif
#if GL_3DFX_texture_compression_FXT1
  "GL_3DFX_texture_compression_FXT1",
#endif
#if GL_AMD_blend_minmax_factor
  "GL_AMD_blend_minmax_factor",
#endif
#if GL_AMD_compressed_3DC_texture
  "GL_AMD_compressed_3DC_texture",
#endif
#if GL_AMD_compressed_ATC_texture
  "GL_AMD_compressed_ATC_texture",
#endif
#if GL_AMD_conservative_depth
  "GL_AMD_conservative_depth",
#endif
#if GL_AMD_debug_output
  "GL_AMD_debug_output",
#endif
#if GL_AMD_depth_clamp_separate
  "GL_AMD_depth_clamp_separate",
#endif
#if GL_AMD_draw_buffers_blend
  "GL_AMD_draw_buffers_blend",
#endif
#if GL_AMD_framebuffer_multisample_advanced
  "GL_AMD_framebuffer_multisample_advanced",
#endif
#if GL_AMD_framebuffer_sample_positions
  "GL_AMD_framebuffer_sample_positions",
#endif
#if GL_AMD_gcn_shader
  "GL_AMD_gcn_shader",
#endif
#if GL_AMD_gpu_shader_half_float
  "GL_AMD_gpu_shader_half_float",
#endif
#if GL_AMD_gpu_shader_half_float_fetch
  "GL_AMD_gpu_shader_half_float_fetch",
#endif
#if GL_AMD_gpu_shader_int16
  "GL_AMD_gpu_shader_int16",
#endif
#if GL_AMD_gpu_shader_int64
  "GL_AMD_gpu_shader_int64",
#endif
#if GL_AMD_interleaved_elements
  "GL_AMD_interleaved_elements",
#endif
#if GL_AMD_multi_draw_indirect
  "GL_AMD_multi_draw_indirect",
#endif
#if GL_AMD_name_gen_delete
  "GL_AMD_name_gen_delete",
#endif
#if GL_AMD_occlusion_query_event
  "GL_AMD_occlusion_query_event",
#endif
#if GL_AMD_performance_monitor
  "GL_AMD_performance_monitor",
#endif
#if GL_AMD_pinned_memory
  "GL_AMD_pinned_memory",
#endif
#if GL_AMD_program_binary_Z400
  "GL_AMD_program_binary_Z400",
#endif
#if GL_AMD_query_buffer_object
  "GL_AMD_query_buffer_object",
#endif
#if GL_AMD_sample_positions
  "GL_AMD_sample_positions",
#endif
#if GL_AMD_seamless_cubemap_per_texture
  "GL_AMD_seamless_cubemap_per_texture",
#endif
#if GL_AMD_shader_atomic_counter_ops
  "GL_AMD_shader_atomic_counter_ops",
#endif
#if GL_AMD_shader_ballot
  "GL_AMD_shader_ballot",
#endif
#if GL_AMD_shader_explicit_vertex_parameter
  "GL_AMD_shader_explicit_vertex_parameter",
#endif
#if GL_AMD_shader_image_load_store_lod
  "GL_AMD_shader_image_load_store_lod",
#endif
#if GL_AMD_shader_stencil_export
  "GL_AMD_shader_stencil_export",
#endif
#if GL_AMD_shader_stencil_value_export
  "GL_AMD_shader_stencil_value_export",
#endif
#if GL_AMD_shader_trinary_minmax
  "GL_AMD_shader_trinary_minmax",
#endif
#if GL_AMD_sparse_texture
  "GL_AMD_sparse_texture",
#endif
#if GL_AMD_stencil_operation_extended
  "GL_AMD_stencil_operation_extended",
#endif
#if GL_AMD_texture_gather_bias_lod
  "GL_AMD_texture_gather_bias_lod",
#endif
#if GL_AMD_texture_texture4
  "GL_AMD_texture_texture4",
#endif
#if GL_AMD_transform_feedback3_lines_triangles
  "GL_AMD_transform_feedback3_lines_triangles",
#endif
#if GL_AMD_transform_feedback4
  "GL_AMD_transform_feedback4",
#endif
#if GL_AMD_vertex_shader_layer
  "GL_AMD_vertex_shader_layer",
#endif
#if GL_AMD_vertex_shader_tessellator
  "GL_AMD_vertex_shader_tessellator",
#endif
#if GL_AMD_vertex_shader_viewport_index
  "GL_AMD_vertex_shader_viewport_index",
#endif
#if GL_ANDROID_extension_pack_es31a
  "GL_ANDROID_extension_pack_es31a",
#endif
#if GL_ANGLE_depth_texture
  "GL_ANGLE_depth_texture",
#endif
#if GL_ANGLE_framebuffer_blit
  "GL_ANGLE_framebuffer_blit",
#endif
#if GL_ANGLE_framebuffer_multisample
  "GL_ANGLE_framebuffer_multisample",
#endif
#if GL_ANGLE_instanced_arrays
  "GL_ANGLE_instanced_arrays",
#endif
#if GL_ANGLE_pack_reverse_row_order
  "GL_ANGLE_pack_reverse_row_order",
#endif
#if GL_ANGLE_program_binary
  "GL_ANGLE_program_binary",
#endif
#if GL_ANGLE_texture_compression_dxt1
  "GL_ANGLE_texture_compression_dxt1",
#endif
#if GL_ANGLE_texture_compression_dxt3
  "GL_ANGLE_texture_compression_dxt3",
#endif
#if GL_ANGLE_texture_compression_dxt5
  "GL_ANGLE_texture_compression_dxt5",
#endif
#if GL_ANGLE_texture_usage
  "GL_ANGLE_texture_usage",
#endif
#if GL_ANGLE_timer_query
  "GL_ANGLE_timer_query",
#endif
#if GL_ANGLE_translated_shader_source
  "GL_ANGLE_translated_shader_source",
#endif
#if GL_APPLE_aux_depth_stencil
  "GL_APPLE_aux_depth_stencil",
#endif
#if GL_APPLE_client_storage
  "GL_APPLE_client_storage",
#endif
#if GL_APPLE_clip_distance
  "GL_APPLE_clip_distance",
#endif
#if GL_APPLE_color_buffer_packed_float
  "GL_APPLE_color_buffer_packed_float",
#endif
#if GL_APPLE_copy_texture_levels
  "GL_APPLE_copy_texture_levels",
#endif
#if GL_APPLE_element_array
  "GL_APPLE_element_array",
#endif
#if GL_APPLE_fence
  "GL_APPLE_fence",
#endif
#if GL_APPLE_float_pixels
  "GL_APPLE_float_pixels",
#endif
#if GL_APPLE_flush_buffer_range
  "GL_APPLE_flush_buffer_range",
#endif
#if GL_APPLE_framebuffer_multisample
  "GL_APPLE_framebuffer_multisample",
#endif
#if GL_APPLE_object_purgeable
  "GL_APPLE_object_purgeable",
#endif
#if GL_APPLE_pixel_buffer
  "GL_APPLE_pixel_buffer",
#endif
#if GL_APPLE_rgb_422
  "GL_APPLE_rgb_422",
#endif
#if GL_APPLE_row_bytes
  "GL_APPLE_row_bytes",
#endif
#if GL_APPLE_specular_vector
  "GL_APPLE_specular_vector",
#endif
#if GL_APPLE_sync
  "GL_APPLE_sync",
#endif
#if GL_APPLE_texture_2D_limited_npot
  "GL_APPLE_texture_2D_limited_npot",
#endif
#if GL_APPLE_texture_format_BGRA8888
  "GL_APPLE_texture_format_BGRA8888",
#endif
#if GL_APPLE_texture_max_level
  "GL_APPLE_texture_max_level",
#endif
#if GL_APPLE_texture_packed_float
  "GL_APPLE_texture_packed_float",
#endif
#if GL_APPLE_texture_range
  "GL_APPLE_texture_range",
#endif
#if GL_APPLE_transform_hint
  "GL_APPLE_transform_hint",
#endif
#if GL_APPLE_vertex_array_object
  "GL_APPLE_vertex_array_object",
#endif
#if GL_APPLE_vertex_array_range
  "GL_APPLE_vertex_array_range",
#endif
#if GL_APPLE_vertex_program_evaluators
  "GL_APPLE_vertex_program_evaluators",
#endif
#if GL_APPLE_ycbcr_422
  "GL_APPLE_ycbcr_422",
#endif
#if GL_ARB_ES2_compatibility
  "GL_ARB_ES2_compatibility",
#endif
#if GL_ARB_ES3_1_compatibility
  "GL_ARB_ES3_1_compatibility",
#endif
#if GL_ARB_ES3_2_compatibility
  "GL_ARB_ES3_2_compatibility",
#endif
#if GL_ARB_ES3_compatibility
  "GL_ARB_ES3_compatibility",
#endif
#if GL_ARB_arrays_of_arrays
  "GL_ARB_arrays_of_arrays",
#endif
#if GL_ARB_base_instance
  "GL_ARB_base_instance",
#endif
#if GL_ARB_bindless_texture
  "GL_ARB_bindless_texture",
#endif
#if GL_ARB_blend_func_extended
  "GL_ARB_blend_func_extended",
#endif
#if GL_ARB_buffer_storage
  "GL_ARB_buffer_storage",
#endif
#if GL_ARB_cl_event
  "GL_ARB_cl_event",
#endif
#if GL_ARB_clear_buffer_object
  "GL_ARB_clear_buffer_object",
#endif
#if GL_ARB_clear_texture
  "GL_ARB_clear_texture",
#endif
#if GL_ARB_clip_control
  "GL_ARB_clip_control",
#endif
#if GL_ARB_color_buffer_float
  "GL_ARB_color_buffer_float",
#endif
#if GL_ARB_compatibility
  "GL_ARB_compatibility",
#endif
#if GL_ARB_compressed_texture_pixel_storage
  "GL_ARB_compressed_texture_pixel_storage",
#endif
#if GL_ARB_compute_shader
  "GL_ARB_compute_shader",
#endif
#if GL_ARB_compute_variable_group_size
  "GL_ARB_compute_variable_group_size",
#endif
#if GL_ARB_conditional_render_inverted
  "GL_ARB_conditional_render_inverted",
#endif
#if GL_ARB_conservative_depth
  "GL_ARB_conservative_depth",
#endif
#if GL_ARB_copy_buffer
  "GL_ARB_copy_buffer",
#endif
#if GL_ARB_copy_image
  "GL_ARB_copy_image",
#endif
#if GL_ARB_cull_distance
  "GL_ARB_cull_distance",
#endif
#if GL_ARB_debug_output
  "GL_ARB_debug_output",
#endif
#if GL_ARB_depth_buffer_float
  "GL_ARB_depth_buffer_float",
#endif
#if GL_ARB_depth_clamp
  "GL_ARB_depth_clamp",
#endif
#if GL_ARB_depth_texture
  "GL_ARB_depth_texture",
#endif
#if GL_ARB_derivative_control
  "GL_ARB_derivative_control",
#endif
#if GL_ARB_direct_state_access
  "GL_ARB_direct_state_access",
#endif
#if GL_ARB_draw_buffers
  "GL_ARB_draw_buffers",
#endif
#if GL_ARB_draw_buffers_blend
  "GL_ARB_draw_buffers_blend",
#endif
#if GL_ARB_draw_elements_base_vertex
  "GL_ARB_draw_elements_base_vertex",
#endif
#if GL_ARB_draw_indirect
  "GL_ARB_draw_indirect",
#endif
#if GL_ARB_draw_instanced
  "GL_ARB_draw_instanced",
#endif
#if GL_ARB_enhanced_layouts
  "GL_ARB_enhanced_layouts",
#endif
#if GL_ARB_explicit_attrib_location
  "GL_ARB_explicit_attrib_location",
#endif
#if GL_ARB_explicit_uniform_location
  "GL_ARB_explicit_uniform_location",
#endif
#if GL_ARB_fragment_coord_conventions
  "GL_ARB_fragment_coord_conventions",
#endif
#if GL_ARB_fragment_layer_viewport
  "GL_ARB_fragment_layer_viewport",
#endif
#if GL_ARB_fragment_program
  "GL_ARB_fragment_program",
#endif
#if GL_ARB_fragment_program_shadow
  "GL_ARB_fragment_program_shadow",
#endif
#if GL_ARB_fragment_shader
  "GL_ARB_fragment_shader",
#endif
#if GL_ARB_fragment_shader_interlock
  "GL_ARB_fragment_shader_interlock",
#endif
#if GL_ARB_framebuffer_no_attachments
  "GL_ARB_framebuffer_no_attachments",
#endif
#if GL_ARB_framebuffer_object
  "GL_ARB_framebuffer_object",
#endif
#if GL_ARB_framebuffer_sRGB
  "GL_ARB_framebuffer_sRGB",
#endif
#if GL_ARB_geometry_shader4
  "GL_ARB_geometry_shader4",
#endif
#if GL_ARB_get_program_binary
  "GL_ARB_get_program_binary",
#endif
#if GL_ARB_get_texture_sub_image
  "GL_ARB_get_texture_sub_image",
#endif
#if GL_ARB_gl_spirv
  "GL_ARB_gl_spirv",
#endif
#if GL_ARB_gpu_shader5
  "GL_ARB_gpu_shader5",
#endif
#if GL_ARB_gpu_shader_fp64
  "GL_ARB_gpu_shader_fp64",
#endif
#if GL_ARB_gpu_shader_int64
  "GL_ARB_gpu_shader_int64",
#endif
#if GL_ARB_half_float_pixel
  "GL_ARB_half_float_pixel",
#endif
#if GL_ARB_half_float_vertex
  "GL_ARB_half_float_vertex",
#endif
#if GL_ARB_imaging
  "GL_ARB_imaging",
#endif
#if GL_ARB_indirect_parameters
  "GL_ARB_indirect_parameters",
#endif
#if GL_ARB_instanced_arrays
  "GL_ARB_instanced_arrays",
#endif
#if GL_ARB_internalformat_query
  "GL_ARB_internalformat_query",
#endif
#if GL_ARB_internalformat_query2
  "GL_ARB_internalformat_query2",
#endif
#if GL_ARB_invalidate_subdata
  "GL_ARB_invalidate_subdata",
#endif
#if GL_ARB_map_buffer_alignment
  "GL_ARB_map_buffer_alignment",
#endif
#if GL_ARB_map_buffer_range
  "GL_ARB_map_buffer_range",
#endif
#if GL_ARB_matrix_palette
  "GL_ARB_matrix_palette",
#endif
#if GL_ARB_multi_bind
  "GL_ARB_multi_bind",
#endif
#if GL_ARB_multi_draw_indirect
  "GL_ARB_multi_draw_indirect",
#endif
#if GL_ARB_multisample
  "GL_ARB_multisample",
#endif
#if GL_ARB_multitexture
  "GL_ARB_multitexture",
#endif
#if GL_ARB_occlusion_query
  "GL_ARB_occlusion_query",
#endif
#if GL_ARB_occlusion_query2
  "GL_ARB_occlusion_query2",
#endif
#if GL_ARB_parallel_shader_compile
  "GL_ARB_parallel_shader_compile",
#endif
#if GL_ARB_pipeline_statistics_query
  "GL_ARB_pipeline_statistics_query",
#endif
#if GL_ARB_pixel_buffer_object
  "GL_ARB_pixel_buffer_object",
#endif
#if GL_ARB_point_parameters
  "GL_ARB_point_parameters",
#endif
#if GL_ARB_point_sprite
  "GL_ARB_point_sprite",
#endif
#if GL_ARB_polygon_offset_clamp
  "GL_ARB_polygon_offset_clamp",
#endif
#if GL_ARB_post_depth_coverage
  "GL_ARB_post_depth_coverage",
#endif
#if GL_ARB_program_interface_query
  "GL_ARB_program_interface_query",
#endif
#if GL_ARB_provoking_vertex
  "GL_ARB_provoking_vertex",
#endif
#if GL_ARB_query_buffer_object
  "GL_ARB_query_buffer_object",
#endif
#if GL_ARB_robust_buffer_access_behavior
  "GL_ARB_robust_buffer_access_behavior",
#endif
#if GL_ARB_robustness
  "GL_ARB_robustness",
#endif
#if GL_ARB_robustness_application_isolation
  "GL_ARB_robustness_application_isolation",
#endif
#if GL_ARB_robustness_share_group_isolation
  "GL_ARB_robustness_share_group_isolation",
#endif
#if GL_ARB_sample_locations
  "GL_ARB_sample_locations",
#endif
#if GL_ARB_sample_shading
  "GL_ARB_sample_shading",
#endif
#if GL_ARB_sampler_objects
  "GL_ARB_sampler_objects",
#endif
#if GL_ARB_seamless_cube_map
  "GL_ARB_seamless_cube_map",
#endif
#if GL_ARB_seamless_cubemap_per_texture
  "GL_ARB_seamless_cubemap_per_texture",
#endif
#if GL_ARB_separate_shader_objects
  "GL_ARB_separate_shader_objects",
#endif
#if GL_ARB_shader_atomic_counter_ops
  "GL_ARB_shader_atomic_counter_ops",
#endif
#if GL_ARB_shader_atomic_counters
  "GL_ARB_shader_atomic_counters",
#endif
#if GL_ARB_shader_ballot
  "GL_ARB_shader_ballot",
#endif
#if GL_ARB_shader_bit_encoding
  "GL_ARB_shader_bit_encoding",
#endif
#if GL_ARB_shader_clock
  "GL_ARB_shader_clock",
#endif
#if GL_ARB_shader_draw_parameters
  "GL_ARB_shader_draw_parameters",
#endif
#if GL_ARB_shader_group_vote
  "GL_ARB_shader_group_vote",
#endif
#if GL_ARB_shader_image_load_store
  "GL_ARB_shader_image_load_store",
#endif
#if GL_ARB_shader_image_size
  "GL_ARB_shader_image_size",
#endif
#if GL_ARB_shader_objects
  "GL_ARB_shader_objects",
#endif
#if GL_ARB_shader_precision
  "GL_ARB_shader_precision",
#endif
#if GL_ARB_shader_stencil_export
  "GL_ARB_shader_stencil_export",
#endif
#if GL_ARB_shader_storage_buffer_object
  "GL_ARB_shader_storage_buffer_object",
#endif
#if GL_ARB_shader_subroutine
  "GL_ARB_shader_subroutine",
#endif
#if GL_ARB_shader_texture_image_samples
  "GL_ARB_shader_texture_image_samples",
#endif
#if GL_ARB_shader_texture_lod
  "GL_ARB_shader_texture_lod",
#endif
#if GL_ARB_shader_viewport_layer_array
  "GL_ARB_shader_viewport_layer_array",
#endif
#if GL_ARB_shading_language_100
  "GL_ARB_shading_language_100",
#endif
#if GL_ARB_shading_language_420pack
  "GL_ARB_shading_language_420pack",
#endif
#if GL_ARB_shading_language_include
  "GL_ARB_shading_language_include",
#endif
#if GL_ARB_shading_language_packing
  "GL_ARB_shading_language_packing",
#endif
#if GL_ARB_shadow
  "GL_ARB_shadow",
#endif
#if GL_ARB_shadow_ambient
  "GL_ARB_shadow_ambient",
#endif
#if GL_ARB_sparse_buffer
  "GL_ARB_sparse_buffer",
#endif
#if GL_ARB_sparse_texture
  "GL_ARB_sparse_texture",
#endif
#if GL_ARB_sparse_texture2
  "GL_ARB_sparse_texture2",
#endif
#if GL_ARB_sparse_texture_clamp
  "GL_ARB_sparse_texture_clamp",
#endif
#if GL_ARB_spirv_extensions
  "GL_ARB_spirv_extensions",
#endif
#if GL_ARB_stencil_texturing
  "GL_ARB_stencil_texturing",
#endif
#if GL_ARB_sync
  "GL_ARB_sync",
#endif
#if GL_ARB_tessellation_shader
  "GL_ARB_tessellation_shader",
#endif
#if GL_ARB_texture_barrier
  "GL_ARB_texture_barrier",
#endif
#if GL_ARB_texture_border_clamp
  "GL_ARB_texture_border_clamp",
#endif
#if GL_ARB_texture_buffer_object
  "GL_ARB_texture_buffer_object",
#endif
#if GL_ARB_texture_buffer_object_rgb32
  "GL_ARB_texture_buffer_object_rgb32",
#endif
#if GL_ARB_texture_buffer_range
  "GL_ARB_texture_buffer_range",
#endif
#if GL_ARB_texture_compression
  "GL_ARB_texture_compression",
#endif
#if GL_ARB_texture_compression_bptc
  "GL_ARB_texture_compression_bptc",
#endif
#if GL_ARB_texture_compression_rgtc
  "GL_ARB_texture_compression_rgtc",
#endif
#if GL_ARB_texture_cube_map
  "GL_ARB_texture_cube_map",
#endif
#if GL_ARB_texture_cube_map_array
  "GL_ARB_texture_cube_map_array",
#endif
#if GL_ARB_texture_env_add
  "GL_ARB_texture_env_add",
#endif
#if GL_ARB_texture_env_combine
  "GL_ARB_texture_env_combine",
#endif
#if GL_ARB_texture_env_crossbar
  "GL_ARB_texture_env_crossbar",
#endif
#if GL_ARB_texture_env_dot3
  "GL_ARB_texture_env_dot3",
#endif
#if GL_ARB_texture_filter_anisotropic
  "GL_ARB_texture_filter_anisotropic",
#endif
#if GL_ARB_texture_filter_minmax
  "GL_ARB_texture_filter_minmax",
#endif
#if GL_ARB_texture_float
  "GL_ARB_texture_float",
#endif
#if GL_ARB_texture_gather
  "GL_ARB_texture_gather",
#endif
#if GL_ARB_texture_mirror_clamp_to_edge
  "GL_ARB_texture_mirror_clamp_to_edge",
#endif
#if GL_ARB_texture_mirrored_repeat
  "GL_ARB_texture_mirrored_repeat",
#endif
#if GL_ARB_texture_multisample
  "GL_ARB_texture_multisample",
#endif
#if GL_ARB_texture_non_power_of_two
  "GL_ARB_texture_non_power_of_two",
#endif
#if GL_ARB_texture_query_levels
  "GL_ARB_texture_query_levels",
#endif
#if GL_ARB_texture_query_lod
  "GL_ARB_texture_query_lod",
#endif
#if GL_ARB_texture_rectangle
  "GL_ARB_texture_rectangle",
#endif
#if GL_ARB_texture_rg
  "GL_ARB_texture_rg",
#endif
#if GL_ARB_texture_rgb10_a2ui
  "GL_ARB_texture_rgb10_a2ui",
#endif
#if GL_ARB_texture_stencil8
  "GL_ARB_texture_stencil8",
#endif
#if GL_ARB_texture_storage
  "GL_ARB_texture_storage",
#endif
#if GL_ARB_texture_storage_multisample
  "GL_ARB_texture_storage_multisample",
#endif
#if GL_ARB_texture_swizzle
  "GL_ARB_texture_swizzle",
#endif
#if GL_ARB_texture_view
  "GL_ARB_texture_view",
#endif
#if GL_ARB_timer_query
  "GL_ARB_timer_query",
#endif
#if GL_ARB_transform_feedback2
  "GL_ARB_transform_feedback2",
#endif
#if GL_ARB_transform_feedback3
  "GL_ARB_transform_feedback3",
#endif
#if GL_ARB_transform_feedback_instanced
  "GL_ARB_transform_feedback_instanced",
#endif
#if GL_ARB_transform_feedback_overflow_query
  "GL_ARB_transform_feedback_overflow_query",
#endif
#if GL_ARB_transpose_matrix
  "GL_ARB_transpose_matrix",
#endif
#if GL_ARB_uniform_buffer_object
  "GL_ARB_uniform_buffer_object",
#endif
#if GL_ARB_vertex_array_bgra
  "GL_ARB_vertex_array_bgra",
#endif
#if GL_ARB_vertex_array_object
  "GL_ARB_vertex_array_object",
#endif
#if GL_ARB_vertex_attrib_64bit
  "GL_ARB_vertex_attrib_64bit",
#endif
#if GL_ARB_vertex_attrib_binding
  "GL_ARB_vertex_attrib_binding",
#endif
#if GL_ARB_vertex_blend
  "GL_ARB_vertex_blend",
#endif
#if GL_ARB_vertex_buffer_object
  "GL_ARB_vertex_buffer_object",
#endif
#if GL_ARB_vertex_program
  "GL_ARB_vertex_program",
#endif
#if GL_ARB_vertex_shader
  "GL_ARB_vertex_shader",
#endif
#if GL_ARB_vertex_type_10f_11f_11f_rev
  "GL_ARB_vertex_type_10f_11f_11f_rev",
#endif
#if GL_ARB_vertex_type_2_10_10_10_rev
  "GL_ARB_vertex_type_2_10_10_10_rev",
#endif
#if GL_ARB_viewport_array
  "GL_ARB_viewport_array",
#endif
#if GL_ARB_window_pos
  "GL_ARB_window_pos",
#endif
#if GL_ARM_mali_program_binary
  "GL_ARM_mali_program_binary",
#endif
#if GL_ARM_mali_shader_binary
  "GL_ARM_mali_shader_binary",
#endif
#if GL_ARM_rgba8
  "GL_ARM_rgba8",
#endif
#if GL_ARM_shader_core_properties
  "GL_ARM_shader_core_properties",
#endif
#if GL_ARM_shader_framebuffer_fetch
  "GL_ARM_shader_framebuffer_fetch",
#endif
#if GL_ARM_shader_framebuffer_fetch_depth_stencil
  "GL_ARM_shader_framebuffer_fetch_depth_stencil",
#endif
#if GL_ARM_texture_unnormalized_coordinates
  "GL_ARM_texture_unnormalized_coordinates",
#endif
#if GL_ATIX_point_sprites
  "GL_ATIX_point_sprites",
#endif
#if GL_ATIX_texture_env_combine3
  "GL_ATIX_texture_env_combine3",
#endif
#if GL_ATIX_texture_env_route
  "GL_ATIX_texture_env_route",
#endif
#if GL_ATIX_vertex_shader_output_point_size
  "GL_ATIX_vertex_shader_output_point_size",
#endif
#if GL_ATI_draw_buffers
  "GL_ATI_draw_buffers",
#endif
#if GL_ATI_element_array
  "GL_ATI_element_array",
#endif
#if GL_ATI_envmap_bumpmap
  "GL_ATI_envmap_bumpmap",
#endif
#if GL_ATI_fragment_shader
  "GL_ATI_fragment_shader",
#endif
#if GL_ATI_map_object_buffer
  "GL_ATI_map_object_buffer",
#endif
#if GL_ATI_meminfo
  "GL_ATI_meminfo",
#endif
#if GL_ATI_pn_triangles
  "GL_ATI_pn_triangles",
#endif
#if GL_ATI_separate_stencil
  "GL_ATI_separate_stencil",
#endif
#if GL_ATI_shader_texture_lod
  "GL_ATI_shader_texture_lod",
#endif
#if GL_ATI_text_fragment_shader
  "GL_ATI_text_fragment_shader",
#endif
#if GL_ATI_texture_compression_3dc
  "GL_ATI_texture_compression_3dc",
#endif
#if GL_ATI_texture_env_combine3
  "GL_ATI_texture_env_combine3",
#endif
#if GL_ATI_texture_float
  "GL_ATI_texture_float",
#endif
#if GL_ATI_texture_mirror_once
  "GL_ATI_texture_mirror_once",
#endif
#if GL_ATI_vertex_array_object
  "GL_ATI_vertex_array_object",
#endif
#if GL_ATI_vertex_attrib_array_object
  "GL_ATI_vertex_attrib_array_object",
#endif
#if GL_ATI_vertex_streams
  "GL_ATI_vertex_streams",
#endif
#if GL_DMP_program_binary
  "GL_DMP_program_binary",
#endif
#if GL_DMP_shader_binary
  "GL_DMP_shader_binary",
#endif
#if GL_EXT_422_pixels
  "GL_EXT_422_pixels",
#endif
#if GL_EXT_Cg_shader
  "GL_EXT_Cg_shader",
#endif
#if GL_EXT_EGL_image_array
  "GL_EXT_EGL_image_array",
#endif
#if GL_EXT_EGL_image_external_wrap_modes
  "GL_EXT_EGL_image_external_wrap_modes",
#endif
#if GL_EXT_EGL_image_storage
  "GL_EXT_EGL_image_storage",
#endif
#if GL_EXT_EGL_image_storage_compression
  "GL_EXT_EGL_image_storage_compression",
#endif
#if GL_EXT_EGL_sync
  "GL_EXT_EGL_sync",
#endif
#if GL_EXT_YUV_target
  "GL_EXT_YUV_target",
#endif
#if GL_EXT_abgr
  "GL_EXT_abgr",
#endif
#if GL_EXT_base_instance
  "GL_EXT_base_instance",
#endif
#if GL_EXT_bgra
  "GL_EXT_bgra",
#endif
#if GL_EXT_bindable_uniform
  "GL_EXT_bindable_uniform",
#endif
#if GL_EXT_blend_color
  "GL_EXT_blend_color",
#endif
#if GL_EXT_blend_equation_separate
  "GL_EXT_blend_equation_separate",
#endif
#if GL_EXT_blend_func_extended
  "GL_EXT_blend_func_extended",
#endif
#if GL_EXT_blend_func_separate
  "GL_EXT_blend_func_separate",
#endif
#if GL_EXT_blend_logic_op
  "GL_EXT_blend_logic_op",
#endif
#if GL_EXT_blend_minmax
  "GL_EXT_blend_minmax",
#endif
#if GL_EXT_blend_subtract
  "GL_EXT_blend_subtract",
#endif
#if GL_EXT_buffer_storage
  "GL_EXT_buffer_storage",
#endif
#if GL_EXT_clear_texture
  "GL_EXT_clear_texture",
#endif
#if GL_EXT_clip_control
  "GL_EXT_clip_control",
#endif
#if GL_EXT_clip_cull_distance
  "GL_EXT_clip_cull_distance",
#endif
#if GL_EXT_clip_volume_hint
  "GL_EXT_clip_volume_hint",
#endif
#if GL_EXT_cmyka
  "GL_EXT_cmyka",
#endif
#if GL_EXT_color_buffer_float
  "GL_EXT_color_buffer_float",
#endif
#if GL_EXT_color_buffer_half_float
  "GL_EXT_color_buffer_half_float",
#endif
#if GL_EXT_color_subtable
  "GL_EXT_color_subtable",
#endif
#if GL_EXT_compiled_vertex_array
  "GL_EXT_compiled_vertex_array",
#endif
#if GL_EXT_compressed_ETC1_RGB8_sub_texture
  "GL_EXT_compressed_ETC1_RGB8_sub_texture",
#endif
#if GL_EXT_conservative_depth
  "GL_EXT_conservative_depth",
#endif
#if GL_EXT_convolution
  "GL_EXT_convolution",
#endif
#if GL_EXT_coordinate_frame
  "GL_EXT_coordinate_frame",
#endif
#if GL_EXT_copy_image
  "GL_EXT_copy_image",
#endif
#if GL_EXT_copy_texture
  "GL_EXT_copy_texture",
#endif
#if GL_EXT_cull_vertex
  "GL_EXT_cull_vertex",
#endif
#if GL_EXT_debug_label
  "GL_EXT_debug_label",
#endif
#if GL_EXT_debug_marker
  "GL_EXT_debug_marker",
#endif
#if GL_EXT_depth_bounds_test
  "GL_EXT_depth_bounds_test",
#endif
#if GL_EXT_depth_clamp
  "GL_EXT_depth_clamp",
#endif
#if GL_EXT_direct_state_access
  "GL_EXT_direct_state_access",
#endif
#if GL_EXT_discard_framebuffer
  "GL_EXT_discard_framebuffer",
#endif
#if GL_EXT_disjoint_timer_query
  "GL_EXT_disjoint_timer_query",
#endif
#if GL_EXT_draw_buffers
  "GL_EXT_draw_buffers",
#endif
#if GL_EXT_draw_buffers2
  "GL_EXT_draw_buffers2",
#endif
#if GL_EXT_draw_buffers_indexed
  "GL_EXT_draw_buffers_indexed",
#endif
#if GL_EXT_draw_elements_base_vertex
  "GL_EXT_draw_elements_base_vertex",
#endif
#if GL_EXT_draw_instanced
  "GL_EXT_draw_instanced",
#endif
#if GL_EXT_draw_range_elements
  "GL_EXT_draw_range_elements",
#endif
#if GL_EXT_draw_transform_feedback
  "GL_EXT_draw_transform_feedback",
#endif
#if GL_EXT_external_buffer
  "GL_EXT_external_buffer",
#endif
#if GL_EXT_float_blend
  "GL_EXT_float_blend",
#endif
#if GL_EXT_fog_coord
  "GL_EXT_fog_coord",
#endif
#if GL_EXT_frag_depth
  "GL_EXT_frag_depth",
#endif
#if GL_EXT_fragment_lighting
  "GL_EXT_fragment_lighting",
#endif
#if GL_EXT_fragment_shading_rate
  "GL_EXT_fragment_shading_rate",
#endif
#if GL_EXT_fragment_shading_rate_attachment
  "GL_EXT_fragment_shading_rate_attachment",
#endif
#if GL_EXT_fragment_shading_rate_primitive
  "GL_EXT_fragment_shading_rate_primitive",
#endif
#if GL_EXT_framebuffer_blit
  "GL_EXT_framebuffer_blit",
#endif
#if GL_EXT_framebuffer_blit_layers
  "GL_EXT_framebuffer_blit_layers",
#endif
#if GL_EXT_framebuffer_multisample
  "GL_EXT_framebuffer_multisample",
#endif
#if GL_EXT_framebuffer_multisample_blit_scaled
  "GL_EXT_framebuffer_multisample_blit_scaled",
#endif
#if GL_EXT_framebuffer_object
  "GL_EXT_framebuffer_object",
#endif
#if GL_EXT_framebuffer_sRGB
  "GL_EXT_framebuffer_sRGB",
#endif
#if GL_EXT_geometry_point_size
  "GL_EXT_geometry_point_size",
#endif
#if GL_EXT_geometry_shader
  "GL_EXT_geometry_shader",
#endif
#if GL_EXT_geometry_shader4
  "GL_EXT_geometry_shader4",
#endif
#if GL_EXT_gpu_program_parameters
  "GL_EXT_gpu_program_parameters",
#endif
#if GL_EXT_gpu_shader4
  "GL_EXT_gpu_shader4",
#endif
#if GL_EXT_gpu_shader5
  "GL_EXT_gpu_shader5",
#endif
#if GL_EXT_histogram
  "GL_EXT_histogram",
#endif
#if GL_EXT_index_array_formats
  "GL_EXT_index_array_formats",
#endif
#if GL_EXT_index_func
  "GL_EXT_index_func",
#endif
#if GL_EXT_index_material
  "GL_EXT_index_material",
#endif
#if GL_EXT_index_texture
  "GL_EXT_index_texture",
#endif
#if GL_EXT_instanced_arrays
  "GL_EXT_instanced_arrays",
#endif
#if GL_EXT_light_texture
  "GL_EXT_light_texture",
#endif
#if GL_EXT_map_buffer_range
  "GL_EXT_map_buffer_range",
#endif
#if GL_EXT_memory_object
  "GL_EXT_memory_object",
#endif
#if GL_EXT_memory_object_fd
  "GL_EXT_memory_object_fd",
#endif
#if GL_EXT_memory_object_win32
  "GL_EXT_memory_object_win32",
#endif
#if GL_EXT_mesh_shader
  "GL_EXT_mesh_shader",
#endif
#if GL_EXT_misc_attribute
  "GL_EXT_misc_attribute",
#endif
#if GL_EXT_multi_draw_arrays
  "GL_EXT_multi_draw_arrays",
#endif
#if GL_EXT_multi_draw_indirect
  "GL_EXT_multi_draw_indirect",
#endif
#if GL_EXT_multiple_textures
  "GL_EXT_multiple_textures",
#endif
#if GL_EXT_multisample
  "GL_EXT_multisample",
#endif
#if GL_EXT_multisample_compatibility
  "GL_EXT_multisample_compatibility",
#endif
#if GL_EXT_multisampled_render_to_texture
  "GL_EXT_multisampled_render_to_texture",
#endif
#if GL_EXT_multisampled_render_to_texture2
  "GL_EXT_multisampled_render_to_texture2",
#endif
#if GL_EXT_multiview_draw_buffers
  "GL_EXT_multiview_draw_buffers",
#endif
#if GL_EXT_multiview_tessellation_geometry_shader
  "GL_EXT_multiview_tessellation_geometry_shader",
#endif
#if GL_EXT_multiview_texture_multisample
  "GL_EXT_multiview_texture_multisample",
#endif
#if GL_EXT_multiview_timer_query
  "GL_EXT_multiview_timer_query",
#endif
#if GL_EXT_occlusion_query_boolean
  "GL_EXT_occlusion_query_boolean",
#endif
#if GL_EXT_packed_depth_stencil
  "GL_EXT_packed_depth_stencil",
#endif
#if GL_EXT_packed_float
  "GL_EXT_packed_float",
#endif
#if GL_EXT_packed_pixels
  "GL_EXT_packed_pixels",
#endif
#if GL_EXT_paletted_texture
  "GL_EXT_paletted_texture",
#endif
#if GL_EXT_pixel_buffer_object
  "GL_EXT_pixel_buffer_object",
#endif
#if GL_EXT_pixel_transform
  "GL_EXT_pixel_transform",
#endif
#if GL_EXT_pixel_transform_color_table
  "GL_EXT_pixel_transform_color_table",
#endif
#if GL_EXT_point_parameters
  "GL_EXT_point_parameters",
#endif
#if GL_EXT_polygon_offset
  "GL_EXT_polygon_offset",
#endif
#if GL_EXT_polygon_offset_clamp
  "GL_EXT_polygon_offset_clamp",
#endif
#if GL_EXT_post_depth_coverage
  "GL_EXT_post_depth_coverage",
#endif
#if GL_EXT_primitive_bounding_box
  "GL_EXT_primitive_bounding_box",
#endif
#if GL_EXT_protected_textures
  "GL_EXT_protected_textures",
#endif
#if GL_EXT_provoking_vertex
  "GL_EXT_provoking_vertex",
#endif
#if GL_EXT_pvrtc_sRGB
  "GL_EXT_pvrtc_sRGB",
#endif
#if GL_EXT_raster_multisample
  "GL_EXT_raster_multisample",
#endif
#if GL_EXT_read_format_bgra
  "GL_EXT_read_format_bgra",
#endif
#if GL_EXT_render_snorm
  "GL_EXT_render_snorm",
#endif
#if GL_EXT_rescale_normal
  "GL_EXT_rescale_normal",
#endif
#if GL_EXT_robustness
  "GL_EXT_robustness",
#endif
#if GL_EXT_sRGB
  "GL_EXT_sRGB",
#endif
#if GL_EXT_sRGB_write_control
  "GL_EXT_sRGB_write_control",
#endif
#if GL_EXT_scene_marker
  "GL_EXT_scene_marker",
#endif
#if GL_EXT_secondary_color
  "GL_EXT_secondary_color",
#endif
#if GL_EXT_semaphore
  "GL_EXT_semaphore",
#endif
#if GL_EXT_semaphore_fd
  "GL_EXT_semaphore_fd",
#endif
#if GL_EXT_semaphore_win32
  "GL_EXT_semaphore_win32",
#endif
#if GL_EXT_separate_depth_stencil
  "GL_EXT_separate_depth_stencil",
#endif
#if GL_EXT_separate_shader_objects
  "GL_EXT_separate_shader_objects",
#endif
#if GL_EXT_separate_specular_color
  "GL_EXT_separate_specular_color",
#endif
#if GL_EXT_shader_clock
  "GL_EXT_shader_clock",
#endif
#if GL_EXT_shader_framebuffer_fetch
  "GL_EXT_shader_framebuffer_fetch",
#endif
#if GL_EXT_shader_framebuffer_fetch_non_coherent
  "GL_EXT_shader_framebuffer_fetch_non_coherent",
#endif
#if GL_EXT_shader_group_vote
  "GL_EXT_shader_group_vote",
#endif
#if GL_EXT_shader_image_load_formatted
  "GL_EXT_shader_image_load_formatted",
#endif
#if GL_EXT_shader_image_load_store
  "GL_EXT_shader_image_load_store",
#endif
#if GL_EXT_shader_implicit_conversions
  "GL_EXT_shader_implicit_conversions",
#endif
#if GL_EXT_shader_integer_mix
  "GL_EXT_shader_integer_mix",
#endif
#if GL_EXT_shader_io_blocks
  "GL_EXT_shader_io_blocks",
#endif
#if GL_EXT_shader_non_constant_global_initializers
  "GL_EXT_shader_non_constant_global_initializers",
#endif
#if GL_EXT_shader_pixel_local_storage
  "GL_EXT_shader_pixel_local_storage",
#endif
#if GL_EXT_shader_pixel_local_storage2
  "GL_EXT_shader_pixel_local_storage2",
#endif
#if GL_EXT_shader_realtime_clock
  "GL_EXT_shader_realtime_clock",
#endif
#if GL_EXT_shader_samples_identical
  "GL_EXT_shader_samples_identical",
#endif
#if GL_EXT_shader_texture_lod
  "GL_EXT_shader_texture_lod",
#endif
#if GL_EXT_shader_texture_samples
  "GL_EXT_shader_texture_samples",
#endif
#if GL_EXT_shadow_funcs
  "GL_EXT_shadow_funcs",
#endif
#if GL_EXT_shadow_samplers
  "GL_EXT_shadow_samplers",
#endif
#if GL_EXT_shared_texture_palette
  "GL_EXT_shared_texture_palette",
#endif
#if GL_EXT_sparse_texture
  "GL_EXT_sparse_texture",
#endif
#if GL_EXT_sparse_texture2
  "GL_EXT_sparse_texture2",
#endif
#if GL_EXT_static_vertex_array
  "GL_EXT_static_vertex_array",
#endif
#if GL_EXT_stencil_clear_tag
  "GL_EXT_stencil_clear_tag",
#endif
#if GL_EXT_stencil_two_side
  "GL_EXT_stencil_two_side",
#endif
#if GL_EXT_stencil_wrap
  "GL_EXT_stencil_wrap",
#endif
#if GL_EXT_subtexture
  "GL_EXT_subtexture",
#endif
#if GL_EXT_tessellation_point_size
  "GL_EXT_tessellation_point_size",
#endif
#if GL_EXT_tessellation_shader
  "GL_EXT_tessellation_shader",
#endif
#if GL_EXT_texture
  "GL_EXT_texture",
#endif
#if GL_EXT_texture3D
  "GL_EXT_texture3D",
#endif
#if GL_EXT_texture_array
  "GL_EXT_texture_array",
#endif
#if GL_EXT_texture_border_clamp
  "GL_EXT_texture_border_clamp",
#endif
#if GL_EXT_texture_buffer
  "GL_EXT_texture_buffer",
#endif
#if GL_EXT_texture_buffer_object
  "GL_EXT_texture_buffer_object",
#endif
#if GL_EXT_texture_compression_astc_decode_mode
  "GL_EXT_texture_compression_astc_decode_mode",
#endif
#if GL_EXT_texture_compression_astc_decode_mode_rgb9e5
  "GL_EXT_texture_compression_astc_decode_mode_rgb9e5",
#endif
#if GL_EXT_texture_compression_bptc
  "GL_EXT_texture_compression_bptc",
#endif
#if GL_EXT_texture_compression_dxt1
  "GL_EXT_texture_compression_dxt1",
#endif
#if GL_EXT_texture_compression_latc
  "GL_EXT_texture_compression_latc",
#endif
#if GL_EXT_texture_compression_rgtc
  "GL_EXT_texture_compression_rgtc",
#endif
#if GL_EXT_texture_compression_s3tc
  "GL_EXT_texture_compression_s3tc",
#endif
#if GL_EXT_texture_compression_s3tc_srgb
  "GL_EXT_texture_compression_s3tc_srgb",
#endif
#if GL_EXT_texture_cube_map
  "GL_EXT_texture_cube_map",
#endif
#if GL_EXT_texture_cube_map_array
  "GL_EXT_texture_cube_map_array",
#endif
#if GL_EXT_texture_edge_clamp
  "GL_EXT_texture_edge_clamp",
#endif
#if GL_EXT_texture_env
  "GL_EXT_texture_env",
#endif
#if GL_EXT_texture_env_add
  "GL_EXT_texture_env_add",
#endif
#if GL_EXT_texture_env_combine
  "GL_EXT_texture_env_combine",
#endif
#if GL_EXT_texture_env_dot3
  "GL_EXT_texture_env_dot3",
#endif
#if GL_EXT_texture_filter_anisotropic
  "GL_EXT_texture_filter_anisotropic",
#endif
#if GL_EXT_texture_filter_minmax
  "GL_EXT_texture_filter_minmax",
#endif
#if GL_EXT_texture_format_BGRA8888
  "GL_EXT_texture_format_BGRA8888",
#endif
#if GL_EXT_texture_format_sRGB_override
  "GL_EXT_texture_format_sRGB_override",
#endif
#if GL_EXT_texture_integer
  "GL_EXT_texture_integer",
#endif
#if GL_EXT_texture_lod_bias
  "GL_EXT_texture_lod_bias",
#endif
#if GL_EXT_texture_mirror_clamp
  "GL_EXT_texture_mirror_clamp",
#endif
#if GL_EXT_texture_mirror_clamp_to_edge
  "GL_EXT_texture_mirror_clamp_to_edge",
#endif
#if GL_EXT_texture_norm16
  "GL_EXT_texture_norm16",
#endif
#if GL_EXT_texture_object
  "GL_EXT_texture_object",
#endif
#if GL_EXT_texture_perturb_normal
  "GL_EXT_texture_perturb_normal",
#endif
#if GL_EXT_texture_query_lod
  "GL_EXT_texture_query_lod",
#endif
#if GL_EXT_texture_rectangle
  "GL_EXT_texture_rectangle",
#endif
#if GL_EXT_texture_rg
  "GL_EXT_texture_rg",
#endif
#if GL_EXT_texture_sRGB
  "GL_EXT_texture_sRGB",
#endif
#if GL_EXT_texture_sRGB_R8
  "GL_EXT_texture_sRGB_R8",
#endif
#if GL_EXT_texture_sRGB_RG8
  "GL_EXT_texture_sRGB_RG8",
#endif
#if GL_EXT_texture_sRGB_decode
  "GL_EXT_texture_sRGB_decode",
#endif
#if GL_EXT_texture_shadow_lod
  "GL_EXT_texture_shadow_lod",
#endif
#if GL_EXT_texture_shared_exponent
  "GL_EXT_texture_shared_exponent",
#endif
#if GL_EXT_texture_snorm
  "GL_EXT_texture_snorm",
#endif
#if GL_EXT_texture_storage
  "GL_EXT_texture_storage",
#endif
#if GL_EXT_texture_storage_compression
  "GL_EXT_texture_storage_compression",
#endif
#if GL_EXT_texture_swizzle
  "GL_EXT_texture_swizzle",
#endif
#if GL_EXT_texture_type_2_10_10_10_REV
  "GL_EXT_texture_type_2_10_10_10_REV",
#endif
#if GL_EXT_texture_view
  "GL_EXT_texture_view",
#endif
#if GL_EXT_timer_query
  "GL_EXT_timer_query",
#endif
#if GL_EXT_transform_feedback
  "GL_EXT_transform_feedback",
#endif
#if GL_EXT_unpack_subimage
  "GL_EXT_unpack_subimage",
#endif
#if GL_EXT_vertex_array
  "GL_EXT_vertex_array",
#endif
#if GL_EXT_vertex_array_bgra
  "GL_EXT_vertex_array_bgra",
#endif
#if GL_EXT_vertex_array_setXXX
  "GL_EXT_vertex_array_setXXX",
#endif
#if GL_EXT_vertex_attrib_64bit
  "GL_EXT_vertex_attrib_64bit",
#endif
#if GL_EXT_vertex_shader
  "GL_EXT_vertex_shader",
#endif
#if GL_EXT_vertex_weighting
  "GL_EXT_vertex_weighting",
#endif
#if GL_EXT_win32_keyed_mutex
  "GL_EXT_win32_keyed_mutex",
#endif
#if GL_EXT_window_rectangles
  "GL_EXT_window_rectangles",
#endif
#if GL_EXT_x11_sync_object
  "GL_EXT_x11_sync_object",
#endif
#if GL_FJ_shader_binary_GCCSO
  "GL_FJ_shader_binary_GCCSO",
#endif
#if GL_GREMEDY_frame_terminator
  "GL_GREMEDY_frame_terminator",
#endif
#if GL_GREMEDY_string_marker
  "GL_GREMEDY_string_marker",
#endif
#if GL_HP_convolution_border_modes
  "GL_HP_convolution_border_modes",
#endif
#if GL_HP_image_transform
  "GL_HP_image_transform",
#endif
#if GL_HP_occlusion_test
  "GL_HP_occlusion_test",
#endif
#if GL_HP_texture_lighting
  "GL_HP_texture_lighting",
#endif
#if GL_HUAWEI_program_binary
  "GL_HUAWEI_program_binary",
#endif
#if GL_HUAWEI_shader_binary
  "GL_HUAWEI_shader_binary",
#endif
#if GL_IBM_cull_vertex
  "GL_IBM_cull_vertex",
#endif
#if GL_IBM_multimode_draw_arrays
  "GL_IBM_multimode_draw_arrays",
#endif
#if GL_IBM_rasterpos_clip
  "GL_IBM_rasterpos_clip",
#endif
#if GL_IBM_static_data
  "GL_IBM_static_data",
#endif
#if GL_IBM_texture_mirrored_repeat
  "GL_IBM_texture_mirrored_repeat",
#endif
#if GL_IBM_vertex_array_lists
  "GL_IBM_vertex_array_lists",
#endif
#if GL_IMG_bindless_texture
  "GL_IMG_bindless_texture",
#endif
#if GL_IMG_framebuffer_downsample
  "GL_IMG_framebuffer_downsample",
#endif
#if GL_IMG_multisampled_render_to_texture
  "GL_IMG_multisampled_render_to_texture",
#endif
#if GL_IMG_program_binary
  "GL_IMG_program_binary",
#endif
#if GL_IMG_pvric_end_to_end_signature
  "GL_IMG_pvric_end_to_end_signature",
#endif
#if GL_IMG_read_format
  "GL_IMG_read_format",
#endif
#if GL_IMG_shader_binary
  "GL_IMG_shader_binary",
#endif
#if GL_IMG_texture_compression_pvrtc
  "GL_IMG_texture_compression_pvrtc",
#endif
#if GL_IMG_texture_compression_pvrtc2
  "GL_IMG_texture_compression_pvrtc2",
#endif
#if GL_IMG_texture_env_enhanced_fixed_function
  "GL_IMG_texture_env_enhanced_fixed_function",
#endif
#if GL_IMG_texture_filter_cubic
  "GL_IMG_texture_filter_cubic",
#endif
#if GL_IMG_tile_region_protection
  "GL_IMG_tile_region_protection",
#endif
#if GL_INGR_color_clamp
  "GL_INGR_color_clamp",
#endif
#if GL_INGR_interlace_read
  "GL_INGR_interlace_read",
#endif
#if GL_INTEL_blackhole_render
  "GL_INTEL_blackhole_render",
#endif
#if GL_INTEL_conservative_rasterization
  "GL_INTEL_conservative_rasterization",
#endif
#if GL_INTEL_fragment_shader_ordering
  "GL_INTEL_fragment_shader_ordering",
#endif
#if GL_INTEL_framebuffer_CMAA
  "GL_INTEL_framebuffer_CMAA",
#endif
#if GL_INTEL_map_texture
  "GL_INTEL_map_texture",
#endif
#if GL_INTEL_parallel_arrays
  "GL_INTEL_parallel_arrays",
#endif
#if GL_INTEL_performance_query
  "GL_INTEL_performance_query",
#endif
#if GL_INTEL_shader_integer_functions2
  "GL_INTEL_shader_integer_functions2",
#endif
#if GL_INTEL_texture_scissor
  "GL_INTEL_texture_scissor",
#endif
#if GL_KHR_blend_equation_advanced
  "GL_KHR_blend_equation_advanced",
#endif
#if GL_KHR_blend_equation_advanced_coherent
  "GL_KHR_blend_equation_advanced_coherent",
#endif
#if GL_KHR_context_flush_control
  "GL_KHR_context_flush_control",
#endif
#if GL_KHR_debug
  "GL_KHR_debug",
#endif
#if GL_KHR_no_error
  "GL_KHR_no_error",
#endif
#if GL_KHR_parallel_shader_compile
  "GL_KHR_parallel_shader_compile",
#endif
#if GL_KHR_robust_buffer_access_behavior
  "GL_KHR_robust_buffer_access_behavior",
#endif
#if GL_KHR_robustness
  "GL_KHR_robustness",
#endif
#if GL_KHR_shader_subgroup
  "GL_KHR_shader_subgroup",
#endif
#if GL_KHR_texture_compression_astc_hdr
  "GL_KHR_texture_compression_astc_hdr",
#endif
#if GL_KHR_texture_compression_astc_ldr
  "GL_KHR_texture_compression_astc_ldr",
#endif
#if GL_KHR_texture_compression_astc_sliced_3d
  "GL_KHR_texture_compression_astc_sliced_3d",
#endif
#if GL_KTX_buffer_region
  "GL_KTX_buffer_region",
#endif
#if GL_MESAX_texture_stack
  "GL_MESAX_texture_stack",
#endif
#if GL_MESA_bgra
  "GL_MESA_bgra",
#endif
#if GL_MESA_framebuffer_flip_x
  "GL_MESA_framebuffer_flip_x",
#endif
#if GL_MESA_framebuffer_flip_y
  "GL_MESA_framebuffer_flip_y",
#endif
#if GL_MESA_framebuffer_swap_xy
  "GL_MESA_framebuffer_swap_xy",
#endif
#if GL_MESA_pack_invert
  "GL_MESA_pack_invert",
#endif
#if GL_MESA_program_binary_formats
  "GL_MESA_program_binary_formats",
#endif
#if GL_MESA_resize_buffers
  "GL_MESA_resize_buffers",
#endif
#if GL_MESA_shader_integer_functions
  "GL_MESA_shader_integer_functions",
#endif
#if GL_MESA_texture_const_bandwidth
  "GL_MESA_texture_const_bandwidth",
#endif
#if GL_MESA_tile_raster_order
  "GL_MESA_tile_raster_order",
#endif
#if GL_MESA_window_pos
  "GL_MESA_window_pos",
#endif
#if GL_MESA_ycbcr_texture
  "GL_MESA_ycbcr_texture",
#endif
#if GL_NVX_blend_equation_advanced_multi_draw_buffers
  "GL_NVX_blend_equation_advanced_multi_draw_buffers",
#endif
#if GL_NVX_conditional_render
  "GL_NVX_conditional_render",
#endif
#if GL_NVX_gpu_memory_info
  "GL_NVX_gpu_memory_info",
#endif
#if GL_NVX_gpu_multicast2
  "GL_NVX_gpu_multicast2",
#endif
#if GL_NVX_linked_gpu_multicast
  "GL_NVX_linked_gpu_multicast",
#endif
#if GL_NVX_progress_fence
  "GL_NVX_progress_fence",
#endif
#if GL_NV_3dvision_settings
  "GL_NV_3dvision_settings",
#endif
#if GL_NV_EGL_stream_consumer_external
  "GL_NV_EGL_stream_consumer_external",
#endif
#if GL_NV_alpha_to_coverage_dither_control
  "GL_NV_alpha_to_coverage_dither_control",
#endif
#if GL_NV_bgr
  "GL_NV_bgr",
#endif
#if GL_NV_bindless_multi_draw_indirect
  "GL_NV_bindless_multi_draw_indirect",
#endif
#if GL_NV_bindless_multi_draw_indirect_count
  "GL_NV_bindless_multi_draw_indirect_count",
#endif
#if GL_NV_bindless_texture
  "GL_NV_bindless_texture",
#endif
#if GL_NV_blend_equation_advanced
  "GL_NV_blend_equation_advanced",
#endif
#if GL_NV_blend_equation_advanced_coherent
  "GL_NV_blend_equation_advanced_coherent",
#endif
#if GL_NV_blend_minmax_factor
  "GL_NV_blend_minmax_factor",
#endif
#if GL_NV_blend_square
  "GL_NV_blend_square",
#endif
#if GL_NV_clip_space_w_scaling
  "GL_NV_clip_space_w_scaling",
#endif
#if GL_NV_command_list
  "GL_NV_command_list",
#endif
#if GL_NV_compute_program5
  "GL_NV_compute_program5",
#endif
#if GL_NV_compute_shader_derivatives
  "GL_NV_compute_shader_derivatives",
#endif
#if GL_NV_conditional_render
  "GL_NV_conditional_render",
#endif
#if GL_NV_conservative_raster
  "GL_NV_conservative_raster",
#endif
#if GL_NV_conservative_raster_dilate
  "GL_NV_conservative_raster_dilate",
#endif
#if GL_NV_conservative_raster_pre_snap
  "GL_NV_conservative_raster_pre_snap",
#endif
#if GL_NV_conservative_raster_pre_snap_triangles
  "GL_NV_conservative_raster_pre_snap_triangles",
#endif
#if GL_NV_conservative_raster_underestimation
  "GL_NV_conservative_raster_underestimation",
#endif
#if GL_NV_copy_buffer
  "GL_NV_copy_buffer",
#endif
#if GL_NV_copy_depth_to_color
  "GL_NV_copy_depth_to_color",
#endif
#if GL_NV_copy_image
  "GL_NV_copy_image",
#endif
#if GL_NV_deep_texture3D
  "GL_NV_deep_texture3D",
#endif
#if GL_NV_depth_buffer_float
  "GL_NV_depth_buffer_float",
#endif
#if GL_NV_depth_clamp
  "GL_NV_depth_clamp",
#endif
#if GL_NV_depth_nonlinear
  "GL_NV_depth_nonlinear",
#endif
#if GL_NV_depth_range_unclamped
  "GL_NV_depth_range_unclamped",
#endif
#if GL_NV_draw_buffers
  "GL_NV_draw_buffers",
#endif
#if GL_NV_draw_instanced
  "GL_NV_draw_instanced",
#endif
#if GL_NV_draw_texture
  "GL_NV_draw_texture",
#endif
#if GL_NV_draw_vulkan_image
  "GL_NV_draw_vulkan_image",
#endif
#if GL_NV_evaluators
  "GL_NV_evaluators",
#endif
#if GL_NV_explicit_attrib_location
  "GL_NV_explicit_attrib_location",
#endif
#if GL_NV_explicit_multisample
  "GL_NV_explicit_multisample",
#endif
#if GL_NV_fbo_color_attachments
  "GL_NV_fbo_color_attachments",
#endif
#if GL_NV_fence
  "GL_NV_fence",
#endif
#if GL_NV_fill_rectangle
  "GL_NV_fill_rectangle",
#endif
#if GL_NV_float_buffer
  "GL_NV_float_buffer",
#endif
#if GL_NV_fog_distance
  "GL_NV_fog_distance",
#endif
#if GL_NV_fragment_coverage_to_color
  "GL_NV_fragment_coverage_to_color",
#endif
#if GL_NV_fragment_program
  "GL_NV_fragment_program",
#endif
#if GL_NV_fragment_program2
  "GL_NV_fragment_program2",
#endif
#if GL_NV_fragment_program4
  "GL_NV_fragment_program4",
#endif
#if GL_NV_fragment_program_option
  "GL_NV_fragment_program_option",
#endif
#if GL_NV_fragment_shader_barycentric
  "GL_NV_fragment_shader_barycentric",
#endif
#if GL_NV_fragment_shader_interlock
  "GL_NV_fragment_shader_interlock",
#endif
#if GL_NV_framebuffer_blit
  "GL_NV_framebuffer_blit",
#endif
#if GL_NV_framebuffer_mixed_samples
  "GL_NV_framebuffer_mixed_samples",
#endif
#if GL_NV_framebuffer_multisample
  "GL_NV_framebuffer_multisample",
#endif
#if GL_NV_framebuffer_multisample_coverage
  "GL_NV_framebuffer_multisample_coverage",
#endif
#if GL_NV_generate_mipmap_sRGB
  "GL_NV_generate_mipmap_sRGB",
#endif
#if GL_NV_geometry_program4
  "GL_NV_geometry_program4",
#endif
#if GL_NV_geometry_shader4
  "GL_NV_geometry_shader4",
#endif
#if GL_NV_geometry_shader_passthrough
  "GL_NV_geometry_shader_passthrough",
#endif
#if GL_NV_gpu_multicast
  "GL_NV_gpu_multicast",
#endif
#if GL_NV_gpu_program4
  "GL_NV_gpu_program4",
#endif
#if GL_NV_gpu_program5
  "GL_NV_gpu_program5",
#endif
#if GL_NV_gpu_program5_mem_extended
  "GL_NV_gpu_program5_mem_extended",
#endif
#if GL_NV_gpu_program_fp64
  "GL_NV_gpu_program_fp64",
#endif
#if GL_NV_gpu_shader5
  "GL_NV_gpu_shader5",
#endif
#if GL_NV_half_float
  "GL_NV_half_float",
#endif
#if GL_NV_image_formats
  "GL_NV_image_formats",
#endif
#if GL_NV_instanced_arrays
  "GL_NV_instanced_arrays",
#endif
#if GL_NV_internalformat_sample_query
  "GL_NV_internalformat_sample_query",
#endif
#if GL_NV_light_max_exponent
  "GL_NV_light_max_exponent",
#endif
#if GL_NV_memory_attachment
  "GL_NV_memory_attachment",
#endif
#if GL_NV_memory_object_sparse
  "GL_NV_memory_object_sparse",
#endif
#if GL_NV_mesh_shader
  "GL_NV_mesh_shader",
#endif
#if GL_NV_multisample_coverage
  "GL_NV_multisample_coverage",
#endif
#if GL_NV_multisample_filter_hint
  "GL_NV_multisample_filter_hint",
#endif
#if GL_NV_non_square_matrices
  "GL_NV_non_square_matrices",
#endif
#if GL_NV_occlusion_query
  "GL_NV_occlusion_query",
#endif
#if GL_NV_pack_subimage
  "GL_NV_pack_subimage",
#endif
#if GL_NV_packed_depth_stencil
  "GL_NV_packed_depth_stencil",
#endif
#if GL_NV_packed_float
  "GL_NV_packed_float",
#endif
#if GL_NV_packed_float_linear
  "GL_NV_packed_float_linear",
#endif
#if GL_NV_parameter_buffer_object
  "GL_NV_parameter_buffer_object",
#endif
#if GL_NV_parameter_buffer_object2
  "GL_NV_parameter_buffer_object2",
#endif
#if GL_NV_path_rendering
  "GL_NV_path_rendering",
#endif
#if GL_NV_path_rendering_shared_edge
  "GL_NV_path_rendering_shared_edge",
#endif
#if GL_NV_pixel_buffer_object
  "GL_NV_pixel_buffer_object",
#endif
#if GL_NV_pixel_data_range
  "GL_NV_pixel_data_range",
#endif
#if GL_NV_platform_binary
  "GL_NV_platform_binary",
#endif
#if GL_NV_point_sprite
  "GL_NV_point_sprite",
#endif
#if GL_NV_polygon_mode
  "GL_NV_polygon_mode",
#endif
#if GL_NV_present_video
  "GL_NV_present_video",
#endif
#if GL_NV_primitive_restart
  "GL_NV_primitive_restart",
#endif
#if GL_NV_primitive_shading_rate
  "GL_NV_primitive_shading_rate",
#endif
#if GL_NV_query_resource_tag
  "GL_NV_query_resource_tag",
#endif
#if GL_NV_read_buffer
  "GL_NV_read_buffer",
#endif
#if GL_NV_read_buffer_front
  "GL_NV_read_buffer_front",
#endif
#if GL_NV_read_depth
  "GL_NV_read_depth",
#endif
#if GL_NV_read_depth_stencil
  "GL_NV_read_depth_stencil",
#endif
#if GL_NV_read_stencil
  "GL_NV_read_stencil",
#endif
#if GL_NV_register_combiners
  "GL_NV_register_combiners",
#endif
#if GL_NV_register_combiners2
  "GL_NV_register_combiners2",
#endif
#if GL_NV_representative_fragment_test
  "GL_NV_representative_fragment_test",
#endif
#if GL_NV_robustness_video_memory_purge
  "GL_NV_robustness_video_memory_purge",
#endif
#if GL_NV_sRGB_formats
  "GL_NV_sRGB_formats",
#endif
#if GL_NV_sample_locations
  "GL_NV_sample_locations",
#endif
#if GL_NV_sample_mask_override_coverage
  "GL_NV_sample_mask_override_coverage",
#endif
#if GL_NV_scissor_exclusive
  "GL_NV_scissor_exclusive",
#endif
#if GL_NV_shader_atomic_counters
  "GL_NV_shader_atomic_counters",
#endif
#if GL_NV_shader_atomic_float
  "GL_NV_shader_atomic_float",
#endif
#if GL_NV_shader_atomic_float64
  "GL_NV_shader_atomic_float64",
#endif
#if GL_NV_shader_atomic_fp16_vector
  "GL_NV_shader_atomic_fp16_vector",
#endif
#if GL_NV_shader_atomic_int64
  "GL_NV_shader_atomic_int64",
#endif
#if GL_NV_shader_buffer_load
  "GL_NV_shader_buffer_load",
#endif
#if GL_NV_shader_noperspective_interpolation
  "GL_NV_shader_noperspective_interpolation",
#endif
#if GL_NV_shader_storage_buffer_object
  "GL_NV_shader_storage_buffer_object",
#endif
#if GL_NV_shader_subgroup_partitioned
  "GL_NV_shader_subgroup_partitioned",
#endif
#if GL_NV_shader_texture_footprint
  "GL_NV_shader_texture_footprint",
#endif
#if GL_NV_shader_thread_group
  "GL_NV_shader_thread_group",
#endif
#if GL_NV_shader_thread_shuffle
  "GL_NV_shader_thread_shuffle",
#endif
#if GL_NV_shading_rate_image
  "GL_NV_shading_rate_image",
#endif
#if GL_NV_shadow_samplers_array
  "GL_NV_shadow_samplers_array",
#endif
#if GL_NV_shadow_samplers_cube
  "GL_NV_shadow_samplers_cube",
#endif
#if GL_NV_stereo_view_rendering
  "GL_NV_stereo_view_rendering",
#endif
#if GL_NV_tessellation_program5
  "GL_NV_tessellation_program5",
#endif
#if GL_NV_texgen_emboss
  "GL_NV_texgen_emboss",
#endif
#if GL_NV_texgen_reflection
  "GL_NV_texgen_reflection",
#endif
#if GL_NV_texture_array
  "GL_NV_texture_array",
#endif
#if GL_NV_texture_barrier
  "GL_NV_texture_barrier",
#endif
#if GL_NV_texture_border_clamp
  "GL_NV_texture_border_clamp",
#endif
#if GL_NV_texture_compression_latc
  "GL_NV_texture_compression_latc",
#endif
#if GL_NV_texture_compression_s3tc
  "GL_NV_texture_compression_s3tc",
#endif
#if GL_NV_texture_compression_s3tc_update
  "GL_NV_texture_compression_s3tc_update",
#endif
#if GL_NV_texture_compression_vtc
  "GL_NV_texture_compression_vtc",
#endif
#if GL_NV_texture_env_combine4
  "GL_NV_texture_env_combine4",
#endif
#if GL_NV_texture_expand_normal
  "GL_NV_texture_expand_normal",
#endif
#if GL_NV_texture_multisample
  "GL_NV_texture_multisample",
#endif
#if GL_NV_texture_npot_2D_mipmap
  "GL_NV_texture_npot_2D_mipmap",
#endif
#if GL_NV_texture_rectangle
  "GL_NV_texture_rectangle",
#endif
#if GL_NV_texture_rectangle_compressed
  "GL_NV_texture_rectangle_compressed",
#endif
#if GL_NV_texture_shader
  "GL_NV_texture_shader",
#endif
#if GL_NV_texture_shader2
  "GL_NV_texture_shader2",
#endif
#if GL_NV_texture_shader3
  "GL_NV_texture_shader3",
#endif
#if GL_NV_timeline_semaphore
  "GL_NV_timeline_semaphore",
#endif
#if GL_NV_transform_feedback
  "GL_NV_transform_feedback",
#endif
#if GL_NV_transform_feedback2
  "GL_NV_transform_feedback2",
#endif
#if GL_NV_uniform_buffer_std430_layout
  "GL_NV_uniform_buffer_std430_layout",
#endif
#if GL_NV_uniform_buffer_unified_memory
  "GL_NV_uniform_buffer_unified_memory",
#endif
#if GL_NV_vdpau_interop
  "GL_NV_vdpau_interop",
#endif
#if GL_NV_vdpau_interop2
  "GL_NV_vdpau_interop2",
#endif
#if GL_NV_vertex_array_range
  "GL_NV_vertex_array_range",
#endif
#if GL_NV_vertex_array_range2
  "GL_NV_vertex_array_range2",
#endif
#if GL_NV_vertex_attrib_integer_64bit
  "GL_NV_vertex_attrib_integer_64bit",
#endif
#if GL_NV_vertex_buffer_unified_memory
  "GL_NV_vertex_buffer_unified_memory",
#endif
#if GL_NV_vertex_program
  "GL_NV_vertex_program",
#endif
#if GL_NV_vertex_program1_1
  "GL_NV_vertex_program1_1",
#endif
#if GL_NV_vertex_program2
  "GL_NV_vertex_program2",
#endif
#if GL_NV_vertex_program2_option
  "GL_NV_vertex_program2_option",
#endif
#if GL_NV_vertex_program3
  "GL_NV_vertex_program3",
#endif
#if GL_NV_vertex_program4
  "GL_NV_vertex_program4",
#endif
#if GL_NV_video_capture
  "GL_NV_video_capture",
#endif
#if GL_NV_viewport_array
  "GL_NV_viewport_array",
#endif
#if GL_NV_viewport_array2
  "GL_NV_viewport_array2",
#endif
#if GL_NV_viewport_swizzle
  "GL_NV_viewport_swizzle",
#endif
#if GL_OES_EGL_image
  "GL_OES_EGL_image",
#endif
#if GL_OES_EGL_image_external
  "GL_OES_EGL_image_external",
#endif
#if GL_OES_EGL_image_external_essl3
  "GL_OES_EGL_image_external_essl3",
#endif
#if GL_OES_blend_equation_separate
  "GL_OES_blend_equation_separate",
#endif
#if GL_OES_blend_func_separate
  "GL_OES_blend_func_separate",
#endif
#if GL_OES_blend_subtract
  "GL_OES_blend_subtract",
#endif
#if GL_OES_byte_coordinates
  "GL_OES_byte_coordinates",
#endif
#if GL_OES_compressed_ETC1_RGB8_texture
  "GL_OES_compressed_ETC1_RGB8_texture",
#endif
#if GL_OES_compressed_paletted_texture
  "GL_OES_compressed_paletted_texture",
#endif
#if GL_OES_copy_image
  "GL_OES_copy_image",
#endif
#if GL_OES_depth24
  "GL_OES_depth24",
#endif
#if GL_OES_depth32
  "GL_OES_depth32",
#endif
#if GL_OES_depth_texture
  "GL_OES_depth_texture",
#endif
#if GL_OES_depth_texture_cube_map
  "GL_OES_depth_texture_cube_map",
#endif
#if GL_OES_draw_buffers_indexed
  "GL_OES_draw_buffers_indexed",
#endif
#if GL_OES_draw_texture
  "GL_OES_draw_texture",
#endif
#if GL_OES_element_index_uint
  "GL_OES_element_index_uint",
#endif
#if GL_OES_extended_matrix_palette
  "GL_OES_extended_matrix_palette",
#endif
#if GL_OES_fbo_render_mipmap
  "GL_OES_fbo_render_mipmap",
#endif
#if GL_OES_fragment_precision_high
  "GL_OES_fragment_precision_high",
#endif
#if GL_OES_framebuffer_object
  "GL_OES_framebuffer_object",
#endif
#if GL_OES_geometry_point_size
  "GL_OES_geometry_point_size",
#endif
#if GL_OES_geometry_shader
  "GL_OES_geometry_shader",
#endif
#if GL_OES_get_program_binary
  "GL_OES_get_program_binary",
#endif
#if GL_OES_gpu_shader5
  "GL_OES_gpu_shader5",
#endif
#if GL_OES_mapbuffer
  "GL_OES_mapbuffer",
#endif
#if GL_OES_matrix_get
  "GL_OES_matrix_get",
#endif
#if GL_OES_matrix_palette
  "GL_OES_matrix_palette",
#endif
#if GL_OES_packed_depth_stencil
  "GL_OES_packed_depth_stencil",
#endif
#if GL_OES_point_size_array
  "GL_OES_point_size_array",
#endif
#if GL_OES_point_sprite
  "GL_OES_point_sprite",
#endif
#if GL_OES_read_format
  "GL_OES_read_format",
#endif
#if GL_OES_required_internalformat
  "GL_OES_required_internalformat",
#endif
#if GL_OES_rgb8_rgba8
  "GL_OES_rgb8_rgba8",
#endif
#if GL_OES_sample_shading
  "GL_OES_sample_shading",
#endif
#if GL_OES_sample_variables
  "GL_OES_sample_variables",
#endif
#if GL_OES_shader_image_atomic
  "GL_OES_shader_image_atomic",
#endif
#if GL_OES_shader_io_blocks
  "GL_OES_shader_io_blocks",
#endif
#if GL_OES_shader_multisample_interpolation
  "GL_OES_shader_multisample_interpolation",
#endif
#if GL_OES_single_precision
  "GL_OES_single_precision",
#endif
#if GL_OES_standard_derivatives
  "GL_OES_standard_derivatives",
#endif
#if GL_OES_stencil1
  "GL_OES_stencil1",
#endif
#if GL_OES_stencil4
  "GL_OES_stencil4",
#endif
#if GL_OES_stencil8
  "GL_OES_stencil8",
#endif
#if GL_OES_surfaceless_context
  "GL_OES_surfaceless_context",
#endif
#if GL_OES_tessellation_point_size
  "GL_OES_tessellation_point_size",
#endif
#if GL_OES_tessellation_shader
  "GL_OES_tessellation_shader",
#endif
#if GL_OES_texture_3D
  "GL_OES_texture_3D",
#endif
#if GL_OES_texture_border_clamp
  "GL_OES_texture_border_clamp",
#endif
#if GL_OES_texture_buffer
  "GL_OES_texture_buffer",
#endif
#if GL_OES_texture_compression_astc
  "GL_OES_texture_compression_astc",
#endif
#if GL_OES_texture_cube_map
  "GL_OES_texture_cube_map",
#endif
#if GL_OES_texture_cube_map_array
  "GL_OES_texture_cube_map_array",
#endif
#if GL_OES_texture_env_crossbar
  "GL_OES_texture_env_crossbar",
#endif
#if GL_OES_texture_mirrored_repeat
  "GL_OES_texture_mirrored_repeat",
#endif
#if GL_OES_texture_npot
  "GL_OES_texture_npot",
#endif
#if GL_OES_texture_stencil8
  "GL_OES_texture_stencil8",
#endif
#if GL_OES_texture_storage_multisample_2d_array
  "GL_OES_texture_storage_multisample_2d_array",
#endif
#if GL_OES_texture_view
  "GL_OES_texture_view",
#endif
#if GL_OES_vertex_array_object
  "GL_OES_vertex_array_object",
#endif
#if GL_OES_vertex_half_float
  "GL_OES_vertex_half_float",
#endif
#if GL_OES_vertex_type_10_10_10_2
  "GL_OES_vertex_type_10_10_10_2",
#endif
#if GL_OML_interlace
  "GL_OML_interlace",
#endif
#if GL_OML_resample
  "GL_OML_resample",
#endif
#if GL_OML_subsample
  "GL_OML_subsample",
#endif
#if GL_OVR_multiview
  "GL_OVR_multiview",
#endif
#if GL_OVR_multiview2
  "GL_OVR_multiview2",
#endif
#if GL_OVR_multiview_multisampled_render_to_texture
  "GL_OVR_multiview_multisampled_render_to_texture",
#endif
#if GL_PGI_misc_hints
  "GL_PGI_misc_hints",
#endif
#if GL_PGI_vertex_hints
  "GL_PGI_vertex_hints",
#endif
#if GL_QCOM_YUV_texture_gather
  "GL_QCOM_YUV_texture_gather",
#endif
#if GL_QCOM_alpha_test
  "GL_QCOM_alpha_test",
#endif
#if GL_QCOM_binning_control
  "GL_QCOM_binning_control",
#endif
#if GL_QCOM_driver_control
  "GL_QCOM_driver_control",
#endif
#if GL_QCOM_extended_get
  "GL_QCOM_extended_get",
#endif
#if GL_QCOM_extended_get2
  "GL_QCOM_extended_get2",
#endif
#if GL_QCOM_frame_extrapolation
  "GL_QCOM_frame_extrapolation",
#endif
#if GL_QCOM_framebuffer_foveated
  "GL_QCOM_framebuffer_foveated",
#endif
#if GL_QCOM_motion_estimation
  "GL_QCOM_motion_estimation",
#endif
#if GL_QCOM_perfmon_global_mode
  "GL_QCOM_perfmon_global_mode",
#endif
#if GL_QCOM_render_sRGB_R8_RG8
  "GL_QCOM_render_sRGB_R8_RG8",
#endif
#if GL_QCOM_render_shared_exponent
  "GL_QCOM_render_shared_exponent",
#endif
#if GL_QCOM_shader_framebuffer_fetch_noncoherent
  "GL_QCOM_shader_framebuffer_fetch_noncoherent",
#endif
#if GL_QCOM_shader_framebuffer_fetch_rate
  "GL_QCOM_shader_framebuffer_fetch_rate",
#endif
#if GL_QCOM_shading_rate
  "GL_QCOM_shading_rate",
#endif
#if GL_QCOM_texture_foveated
  "GL_QCOM_texture_foveated",
#endif
#if GL_QCOM_texture_foveated2
  "GL_QCOM_texture_foveated2",
#endif
#if GL_QCOM_texture_foveated_subsampled_layout
  "GL_QCOM_texture_foveated_subsampled_layout",
#endif
#if GL_QCOM_texture_lod_bias
  "GL_QCOM_texture_lod_bias",
#endif
#if GL_QCOM_tiled_rendering
  "GL_QCOM_tiled_rendering",
#endif
#if GL_QCOM_writeonly_rendering
  "GL_QCOM_writeonly_rendering",
#endif
#if GL_QCOM_ycbcr_degamma
  "GL_QCOM_ycbcr_degamma",
#endif
#if GL_REGAL_ES1_0_compatibility
  "GL_REGAL_ES1_0_compatibility",
#endif
#if GL_REGAL_ES1_1_compatibility
  "GL_REGAL_ES1_1_compatibility",
#endif
#if GL_REGAL_enable
  "GL_REGAL_enable",
#endif
#if GL_REGAL_error_string
  "GL_REGAL_error_string",
#endif
#if GL_REGAL_extension_query
  "GL_REGAL_extension_query",
#endif
#if GL_REGAL_log
  "GL_REGAL_log",
#endif
#if GL_REGAL_proc_address
  "GL_REGAL_proc_address",
#endif
#if GL_REND_screen_coordinates
  "GL_REND_screen_coordinates",
#endif
#if GL_S3_s3tc
  "GL_S3_s3tc",
#endif
#if GL_SGIS_clip_band_hint
  "GL_SGIS_clip_band_hint",
#endif
#if GL_SGIS_color_range
  "GL_SGIS_color_range",
#endif
#if GL_SGIS_detail_texture
  "GL_SGIS_detail_texture",
#endif
#if GL_SGIS_fog_function
  "GL_SGIS_fog_function",
#endif
#if GL_SGIS_generate_mipmap
  "GL_SGIS_generate_mipmap",
#endif
#if GL_SGIS_line_texgen
  "GL_SGIS_line_texgen",
#endif
#if GL_SGIS_multisample
  "GL_SGIS_multisample",
#endif
#if GL_SGIS_multitexture
  "GL_SGIS_multitexture",
#endif
#if GL_SGIS_pixel_texture
  "GL_SGIS_pixel_texture",
#endif
#if GL_SGIS_point_line_texgen
  "GL_SGIS_point_line_texgen",
#endif
#if GL_SGIS_shared_multisample
  "GL_SGIS_shared_multisample",
#endif
#if GL_SGIS_sharpen_texture
  "GL_SGIS_sharpen_texture",
#endif
#if GL_SGIS_texture4D
  "GL_SGIS_texture4D",
#endif
#if GL_SGIS_texture_border_clamp
  "GL_SGIS_texture_border_clamp",
#endif
#if GL_SGIS_texture_edge_clamp
  "GL_SGIS_texture_edge_clamp",
#endif
#if GL_SGIS_texture_filter4
  "GL_SGIS_texture_filter4",
#endif
#if GL_SGIS_texture_lod
  "GL_SGIS_texture_lod",
#endif
#if GL_SGIS_texture_select
  "GL_SGIS_texture_select",
#endif
#if GL_SGIX_async
  "GL_SGIX_async",
#endif
#if GL_SGIX_async_histogram
  "GL_SGIX_async_histogram",
#endif
#if GL_SGIX_async_pixel
  "GL_SGIX_async_pixel",
#endif
#if GL_SGIX_bali_g_instruments
  "GL_SGIX_bali_g_instruments",
#endif
#if GL_SGIX_bali_r_instruments
  "GL_SGIX_bali_r_instruments",
#endif
#if GL_SGIX_bali_timer_instruments
  "GL_SGIX_bali_timer_instruments",
#endif
#if GL_SGIX_blend_alpha_minmax
  "GL_SGIX_blend_alpha_minmax",
#endif
#if GL_SGIX_blend_cadd
  "GL_SGIX_blend_cadd",
#endif
#if GL_SGIX_blend_cmultiply
  "GL_SGIX_blend_cmultiply",
#endif
#if GL_SGIX_calligraphic_fragment
  "GL_SGIX_calligraphic_fragment",
#endif
#if GL_SGIX_clipmap
  "GL_SGIX_clipmap",
#endif
#if GL_SGIX_color_matrix_accuracy
  "GL_SGIX_color_matrix_accuracy",
#endif
#if GL_SGIX_color_table_index_mode
  "GL_SGIX_color_table_index_mode",
#endif
#if GL_SGIX_complex_polar
  "GL_SGIX_complex_polar",
#endif
#if GL_SGIX_convolution_accuracy
  "GL_SGIX_convolution_accuracy",
#endif
#if GL_SGIX_cube_map
  "GL_SGIX_cube_map",
#endif
#if GL_SGIX_cylinder_texgen
  "GL_SGIX_cylinder_texgen",
#endif
#if GL_SGIX_datapipe
  "GL_SGIX_datapipe",
#endif
#if GL_SGIX_decimation
  "GL_SGIX_decimation",
#endif
#if GL_SGIX_depth_pass_instrument
  "GL_SGIX_depth_pass_instrument",
#endif
#if GL_SGIX_depth_texture
  "GL_SGIX_depth_texture",
#endif
#if GL_SGIX_dvc
  "GL_SGIX_dvc",
#endif
#if GL_SGIX_flush_raster
  "GL_SGIX_flush_raster",
#endif
#if GL_SGIX_fog_blend
  "GL_SGIX_fog_blend",
#endif
#if GL_SGIX_fog_factor_to_alpha
  "GL_SGIX_fog_factor_to_alpha",
#endif
#if GL_SGIX_fog_layers
  "GL_SGIX_fog_layers",
#endif
#if GL_SGIX_fog_offset
  "GL_SGIX_fog_offset",
#endif
#if GL_SGIX_fog_patchy
  "GL_SGIX_fog_patchy",
#endif
#if GL_SGIX_fog_scale
  "GL_SGIX_fog_scale",
#endif
#if GL_SGIX_fog_texture
  "GL_SGIX_fog_texture",
#endif
#if GL_SGIX_fragment_lighting_space
  "GL_SGIX_fragment_lighting_space",
#endif
#if GL_SGIX_fragment_specular_lighting
  "GL_SGIX_fragment_specular_lighting",
#endif
#if GL_SGIX_fragments_instrument
  "GL_SGIX_fragments_instrument",
#endif
#if GL_SGIX_framezoom
  "GL_SGIX_framezoom",
#endif
#if GL_SGIX_icc_texture
  "GL_SGIX_icc_texture",
#endif
#if GL_SGIX_igloo_interface
  "GL_SGIX_igloo_interface",
#endif
#if GL_SGIX_image_compression
  "GL_SGIX_image_compression",
#endif
#if GL_SGIX_impact_pixel_texture
  "GL_SGIX_impact_pixel_texture",
#endif
#if GL_SGIX_instrument_error
  "GL_SGIX_instrument_error",
#endif
#if GL_SGIX_interlace
  "GL_SGIX_interlace",
#endif
#if GL_SGIX_ir_instrument1
  "GL_SGIX_ir_instrument1",
#endif
#if GL_SGIX_line_quality_hint
  "GL_SGIX_line_quality_hint",
#endif
#if GL_SGIX_list_priority
  "GL_SGIX_list_priority",
#endif
#if GL_SGIX_mpeg1
  "GL_SGIX_mpeg1",
#endif
#if GL_SGIX_mpeg2
  "GL_SGIX_mpeg2",
#endif
#if GL_SGIX_nonlinear_lighting_pervertex
  "GL_SGIX_nonlinear_lighting_pervertex",
#endif
#if GL_SGIX_nurbs_eval
  "GL_SGIX_nurbs_eval",
#endif
#if GL_SGIX_occlusion_instrument
  "GL_SGIX_occlusion_instrument",
#endif
#if GL_SGIX_packed_6bytes
  "GL_SGIX_packed_6bytes",
#endif
#if GL_SGIX_pixel_texture
  "GL_SGIX_pixel_texture",
#endif
#if GL_SGIX_pixel_texture_bits
  "GL_SGIX_pixel_texture_bits",
#endif
#if GL_SGIX_pixel_texture_lod
  "GL_SGIX_pixel_texture_lod",
#endif
#if GL_SGIX_pixel_tiles
  "GL_SGIX_pixel_tiles",
#endif
#if GL_SGIX_polynomial_ffd
  "GL_SGIX_polynomial_ffd",
#endif
#if GL_SGIX_quad_mesh
  "GL_SGIX_quad_mesh",
#endif
#if GL_SGIX_reference_plane
  "GL_SGIX_reference_plane",
#endif
#if GL_SGIX_resample
  "GL_SGIX_resample",
#endif
#if GL_SGIX_scalebias_hint
  "GL_SGIX_scalebias_hint",
#endif
#if GL_SGIX_shadow
  "GL_SGIX_shadow",
#endif
#if GL_SGIX_shadow_ambient
  "GL_SGIX_shadow_ambient",
#endif
#if GL_SGIX_slim
  "GL_SGIX_slim",
#endif
#if GL_SGIX_spotlight_cutoff
  "GL_SGIX_spotlight_cutoff",
#endif
#if GL_SGIX_sprite
  "GL_SGIX_sprite",
#endif
#if GL_SGIX_subdiv_patch
  "GL_SGIX_subdiv_patch",
#endif
#if GL_SGIX_subsample
  "GL_SGIX_subsample",
#endif
#if GL_SGIX_tag_sample_buffer
  "GL_SGIX_tag_sample_buffer",
#endif
#if GL_SGIX_texture_add_env
  "GL_SGIX_texture_add_env",
#endif
#if GL_SGIX_texture_coordinate_clamp
  "GL_SGIX_texture_coordinate_clamp",
#endif
#if GL_SGIX_texture_lod_bias
  "GL_SGIX_texture_lod_bias",
#endif
#if GL_SGIX_texture_mipmap_anisotropic
  "GL_SGIX_texture_mipmap_anisotropic",
#endif
#if GL_SGIX_texture_multi_buffer
  "GL_SGIX_texture_multi_buffer",
#endif
#if GL_SGIX_texture_phase
  "GL_SGIX_texture_phase",
#endif
#if GL_SGIX_texture_range
  "GL_SGIX_texture_range",
#endif
#if GL_SGIX_texture_scale_bias
  "GL_SGIX_texture_scale_bias",
#endif
#if GL_SGIX_texture_supersample
  "GL_SGIX_texture_supersample",
#endif
#if GL_SGIX_vector_ops
  "GL_SGIX_vector_ops",
#endif
#if GL_SGIX_vertex_array_object
  "GL_SGIX_vertex_array_object",
#endif
#if GL_SGIX_vertex_preclip
  "GL_SGIX_vertex_preclip",
#endif
#if GL_SGIX_vertex_preclip_hint
  "GL_SGIX_vertex_preclip_hint",
#endif
#if GL_SGIX_ycrcb
  "GL_SGIX_ycrcb",
#endif
#if GL_SGIX_ycrcb_subsample
  "GL_SGIX_ycrcb_subsample",
#endif
#if GL_SGIX_ycrcba
  "GL_SGIX_ycrcba",
#endif
#if GL_SGI_color_matrix
  "GL_SGI_color_matrix",
#endif
#if GL_SGI_color_table
  "GL_SGI_color_table",
#endif
#if GL_SGI_complex
  "GL_SGI_complex",
#endif
#if GL_SGI_complex_type
  "GL_SGI_complex_type",
#endif
#if GL_SGI_fft
  "GL_SGI_fft",
#endif
#if GL_SGI_texture_color_table
  "GL_SGI_texture_color_table",
#endif
#if GL_SUNX_constant_data
  "GL_SUNX_constant_data",
#endif
#if GL_SUN_convolution_border_modes
  "GL_SUN_convolution_border_modes",
#endif
#if GL_SUN_global_alpha
  "GL_SUN_global_alpha",
#endif
#if GL_SUN_mesh_array
  "GL_SUN_mesh_array",
#endif
#if GL_SUN_read_video_pixels
  "GL_SUN_read_video_pixels",
#endif
#if GL_SUN_slice_accum
  "GL_SUN_slice_accum",
#endif
#if GL_SUN_triangle_list
  "GL_SUN_triangle_list",
#endif
#if GL_SUN_vertex
  "GL_SUN_vertex",
#endif
#if GL_VERSION_1_2
  "GL_VERSION_1_2",
#endif
#if GL_VERSION_1_2_1
  "GL_VERSION_1_2_1",
#endif
#if GL_VERSION_1_3
  "GL_VERSION_1_3",
#endif
#if GL_VERSION_1_4
  "GL_VERSION_1_4",
#endif
#if GL_VERSION_1_5
  "GL_VERSION_1_5",
#endif
#if GL_VERSION_2_0
  "GL_VERSION_2_0",
#endif
#if GL_VERSION_2_1
  "GL_VERSION_2_1",
#endif
#if GL_VERSION_3_0
  "GL_VERSION_3_0",
#endif
#if GL_VERSION_3_1
  "GL_VERSION_3_1",
#endif
#if GL_VERSION_3_2
  "GL_VERSION_3_2",
#endif
#if GL_VERSION_3_3
  "GL_VERSION_3_3",
#endif
#if GL_VERSION_4_0
  "GL_VERSION_4_0",
#endif
#if GL_VERSION_4_1
  "GL_VERSION_4_1",
#endif
#if GL_VERSION_4_2
  "GL_VERSION_4_2",
#endif
#if GL_VERSION_4_3
  "GL_VERSION_4_3",
#endif
#if GL_VERSION_4_4
  "GL_VERSION_4_4",
#endif
#if GL_VERSION_4_5
  "GL_VERSION_4_5",
#endif
#if GL_VERSION_4_6
  "GL_VERSION_4_6",
#endif
#if GL_VIV_shader_binary
  "GL_VIV_shader_binary",
#endif
#if GL_WIN_phong_shading
  "GL_WIN_phong_shading",
#endif
#if GL_WIN_scene_markerXXX
  "GL_WIN_scene_markerXXX",
#endif
#if GL_WIN_specular_fog
  "GL_WIN_specular_fog",
#endif
#if GL_WIN_swap_hint
  "GL_WIN_swap_hint"
#endif
};

        internal static RefBool[] _glewExtensionString = new RefBool[964];
        internal static RefBool[] _glewExtensionEnabled = {
#if !GL_3DFX_multisample
  __GLEW_3DFX_multisample,
#endif
#if GL_3DFX_tbuffer
  __GLEW_3DFX_tbuffer,
#endif
#if GL_3DFX_texture_compression_FXT1
  __GLEW_3DFX_texture_compression_FXT1,
#endif
#if GL_AMD_blend_minmax_factor
  __GLEW_AMD_blend_minmax_factor,
#endif
#if GL_AMD_compressed_3DC_texture
  __GLEW_AMD_compressed_3DC_texture,
#endif
#if GL_AMD_compressed_ATC_texture
  __GLEW_AMD_compressed_ATC_texture,
#endif
#if GL_AMD_conservative_depth
  __GLEW_AMD_conservative_depth,
#endif
#if GL_AMD_debug_output
  __GLEW_AMD_debug_output,
#endif
#if GL_AMD_depth_clamp_separate
  __GLEW_AMD_depth_clamp_separate,
#endif
#if GL_AMD_draw_buffers_blend
  __GLEW_AMD_draw_buffers_blend,
#endif
#if GL_AMD_framebuffer_multisample_advanced
  __GLEW_AMD_framebuffer_multisample_advanced,
#endif
#if GL_AMD_framebuffer_sample_positions
  __GLEW_AMD_framebuffer_sample_positions,
#endif
#if GL_AMD_gcn_shader
  __GLEW_AMD_gcn_shader,
#endif
#if GL_AMD_gpu_shader_half_float
  __GLEW_AMD_gpu_shader_half_float,
#endif
#if GL_AMD_gpu_shader_half_float_fetch
  __GLEW_AMD_gpu_shader_half_float_fetch,
#endif
#if GL_AMD_gpu_shader_int16
  __GLEW_AMD_gpu_shader_int16,
#endif
#if GL_AMD_gpu_shader_int64
  __GLEW_AMD_gpu_shader_int64,
#endif
#if GL_AMD_interleaved_elements
  __GLEW_AMD_interleaved_elements,
#endif
#if GL_AMD_multi_draw_indirect
  __GLEW_AMD_multi_draw_indirect,
#endif
#if GL_AMD_name_gen_delete
  __GLEW_AMD_name_gen_delete,
#endif
#if GL_AMD_occlusion_query_event
  __GLEW_AMD_occlusion_query_event,
#endif
#if GL_AMD_performance_monitor
  __GLEW_AMD_performance_monitor,
#endif
#if GL_AMD_pinned_memory
  __GLEW_AMD_pinned_memory,
#endif
#if GL_AMD_program_binary_Z400
  __GLEW_AMD_program_binary_Z400,
#endif
#if GL_AMD_query_buffer_object
  __GLEW_AMD_query_buffer_object,
#endif
#if GL_AMD_sample_positions
  __GLEW_AMD_sample_positions,
#endif
#if GL_AMD_seamless_cubemap_per_texture
  __GLEW_AMD_seamless_cubemap_per_texture,
#endif
#if GL_AMD_shader_atomic_counter_ops
  __GLEW_AMD_shader_atomic_counter_ops,
#endif
#if GL_AMD_shader_ballot
  __GLEW_AMD_shader_ballot,
#endif
#if GL_AMD_shader_explicit_vertex_parameter
  __GLEW_AMD_shader_explicit_vertex_parameter,
#endif
#if GL_AMD_shader_image_load_store_lod
  __GLEW_AMD_shader_image_load_store_lod,
#endif
#if GL_AMD_shader_stencil_export
  __GLEW_AMD_shader_stencil_export,
#endif
#if GL_AMD_shader_stencil_value_export
  __GLEW_AMD_shader_stencil_value_export,
#endif
#if GL_AMD_shader_trinary_minmax
  __GLEW_AMD_shader_trinary_minmax,
#endif
#if GL_AMD_sparse_texture
  __GLEW_AMD_sparse_texture,
#endif
#if GL_AMD_stencil_operation_extended
  __GLEW_AMD_stencil_operation_extended,
#endif
#if GL_AMD_texture_gather_bias_lod
  __GLEW_AMD_texture_gather_bias_lod,
#endif
#if GL_AMD_texture_texture4
  __GLEW_AMD_texture_texture4,
#endif
#if GL_AMD_transform_feedback3_lines_triangles
  __GLEW_AMD_transform_feedback3_lines_triangles,
#endif
#if GL_AMD_transform_feedback4
  __GLEW_AMD_transform_feedback4,
#endif
#if GL_AMD_vertex_shader_layer
  __GLEW_AMD_vertex_shader_layer,
#endif
#if GL_AMD_vertex_shader_tessellator
  __GLEW_AMD_vertex_shader_tessellator,
#endif
#if GL_AMD_vertex_shader_viewport_index
  __GLEW_AMD_vertex_shader_viewport_index,
#endif
#if GL_ANDROID_extension_pack_es31a
  __GLEW_ANDROID_extension_pack_es31a,
#endif
#if GL_ANGLE_depth_texture
  __GLEW_ANGLE_depth_texture,
#endif
#if GL_ANGLE_framebuffer_blit
  __GLEW_ANGLE_framebuffer_blit,
#endif
#if GL_ANGLE_framebuffer_multisample
  __GLEW_ANGLE_framebuffer_multisample,
#endif
#if GL_ANGLE_instanced_arrays
  __GLEW_ANGLE_instanced_arrays,
#endif
#if GL_ANGLE_pack_reverse_row_order
  __GLEW_ANGLE_pack_reverse_row_order,
#endif
#if GL_ANGLE_program_binary
  __GLEW_ANGLE_program_binary,
#endif
#if GL_ANGLE_texture_compression_dxt1
  __GLEW_ANGLE_texture_compression_dxt1,
#endif
#if GL_ANGLE_texture_compression_dxt3
  __GLEW_ANGLE_texture_compression_dxt3,
#endif
#if GL_ANGLE_texture_compression_dxt5
  __GLEW_ANGLE_texture_compression_dxt5,
#endif
#if GL_ANGLE_texture_usage
  __GLEW_ANGLE_texture_usage,
#endif
#if GL_ANGLE_timer_query
  __GLEW_ANGLE_timer_query,
#endif
#if GL_ANGLE_translated_shader_source
  __GLEW_ANGLE_translated_shader_source,
#endif
#if GL_APPLE_aux_depth_stencil
  __GLEW_APPLE_aux_depth_stencil,
#endif
#if GL_APPLE_client_storage
  __GLEW_APPLE_client_storage,
#endif
#if GL_APPLE_clip_distance
  __GLEW_APPLE_clip_distance,
#endif
#if GL_APPLE_color_buffer_packed_float
  __GLEW_APPLE_color_buffer_packed_float,
#endif
#if GL_APPLE_copy_texture_levels
  __GLEW_APPLE_copy_texture_levels,
#endif
#if GL_APPLE_element_array
  __GLEW_APPLE_element_array,
#endif
#if GL_APPLE_fence
  __GLEW_APPLE_fence,
#endif
#if GL_APPLE_float_pixels
  __GLEW_APPLE_float_pixels,
#endif
#if GL_APPLE_flush_buffer_range
  __GLEW_APPLE_flush_buffer_range,
#endif
#if GL_APPLE_framebuffer_multisample
  __GLEW_APPLE_framebuffer_multisample,
#endif
#if GL_APPLE_object_purgeable
  __GLEW_APPLE_object_purgeable,
#endif
#if GL_APPLE_pixel_buffer
  __GLEW_APPLE_pixel_buffer,
#endif
#if GL_APPLE_rgb_422
  __GLEW_APPLE_rgb_422,
#endif
#if GL_APPLE_row_bytes
  __GLEW_APPLE_row_bytes,
#endif
#if GL_APPLE_specular_vector
  __GLEW_APPLE_specular_vector,
#endif
#if GL_APPLE_sync
  __GLEW_APPLE_sync,
#endif
#if GL_APPLE_texture_2D_limited_npot
  __GLEW_APPLE_texture_2D_limited_npot,
#endif
#if GL_APPLE_texture_format_BGRA8888
  __GLEW_APPLE_texture_format_BGRA8888,
#endif
#if GL_APPLE_texture_max_level
  __GLEW_APPLE_texture_max_level,
#endif
#if GL_APPLE_texture_packed_float
  __GLEW_APPLE_texture_packed_float,
#endif
#if GL_APPLE_texture_range
  __GLEW_APPLE_texture_range,
#endif
#if GL_APPLE_transform_hint
  __GLEW_APPLE_transform_hint,
#endif
#if GL_APPLE_vertex_array_object
  __GLEW_APPLE_vertex_array_object,
#endif
#if GL_APPLE_vertex_array_range
  __GLEW_APPLE_vertex_array_range,
#endif
#if GL_APPLE_vertex_program_evaluators
  __GLEW_APPLE_vertex_program_evaluators,
#endif
#if GL_APPLE_ycbcr_422
  __GLEW_APPLE_ycbcr_422,
#endif
#if GL_ARB_ES2_compatibility
  __GLEW_ARB_ES2_compatibility,
#endif
#if GL_ARB_ES3_1_compatibility
  __GLEW_ARB_ES3_1_compatibility,
#endif
#if GL_ARB_ES3_2_compatibility
  __GLEW_ARB_ES3_2_compatibility,
#endif
#if GL_ARB_ES3_compatibility
  __GLEW_ARB_ES3_compatibility,
#endif
#if GL_ARB_arrays_of_arrays
  __GLEW_ARB_arrays_of_arrays,
#endif
#if GL_ARB_base_instance
  __GLEW_ARB_base_instance,
#endif
#if GL_ARB_bindless_texture
  __GLEW_ARB_bindless_texture,
#endif
#if GL_ARB_blend_func_extended
  __GLEW_ARB_blend_func_extended,
#endif
#if GL_ARB_buffer_storage
  __GLEW_ARB_buffer_storage,
#endif
#if GL_ARB_cl_event
  __GLEW_ARB_cl_event,
#endif
#if GL_ARB_clear_buffer_object
  __GLEW_ARB_clear_buffer_object,
#endif
#if GL_ARB_clear_texture
  __GLEW_ARB_clear_texture,
#endif
#if GL_ARB_clip_control
  __GLEW_ARB_clip_control,
#endif
#if GL_ARB_color_buffer_float
  __GLEW_ARB_color_buffer_float,
#endif
#if GL_ARB_compatibility
  __GLEW_ARB_compatibility,
#endif
#if GL_ARB_compressed_texture_pixel_storage
  __GLEW_ARB_compressed_texture_pixel_storage,
#endif
#if GL_ARB_compute_shader
  __GLEW_ARB_compute_shader,
#endif
#if GL_ARB_compute_variable_group_size
  __GLEW_ARB_compute_variable_group_size,
#endif
#if GL_ARB_conditional_render_inverted
  __GLEW_ARB_conditional_render_inverted,
#endif
#if GL_ARB_conservative_depth
  __GLEW_ARB_conservative_depth,
#endif
#if GL_ARB_copy_buffer
  __GLEW_ARB_copy_buffer,
#endif
#if GL_ARB_copy_image
  __GLEW_ARB_copy_image,
#endif
#if GL_ARB_cull_distance
  __GLEW_ARB_cull_distance,
#endif
#if GL_ARB_debug_output
  __GLEW_ARB_debug_output,
#endif
#if GL_ARB_depth_buffer_float
  __GLEW_ARB_depth_buffer_float,
#endif
#if GL_ARB_depth_clamp
  __GLEW_ARB_depth_clamp,
#endif
#if GL_ARB_depth_texture
  __GLEW_ARB_depth_texture,
#endif
#if GL_ARB_derivative_control
  __GLEW_ARB_derivative_control,
#endif
#if GL_ARB_direct_state_access
  __GLEW_ARB_direct_state_access,
#endif
#if GL_ARB_draw_buffers
  __GLEW_ARB_draw_buffers,
#endif
#if GL_ARB_draw_buffers_blend
  __GLEW_ARB_draw_buffers_blend,
#endif
#if GL_ARB_draw_elements_base_vertex
  __GLEW_ARB_draw_elements_base_vertex,
#endif
#if GL_ARB_draw_indirect
  __GLEW_ARB_draw_indirect,
#endif
#if GL_ARB_draw_instanced
  __GLEW_ARB_draw_instanced,
#endif
#if GL_ARB_enhanced_layouts
  __GLEW_ARB_enhanced_layouts,
#endif
#if GL_ARB_explicit_attrib_location
  __GLEW_ARB_explicit_attrib_location,
#endif
#if GL_ARB_explicit_uniform_location
  __GLEW_ARB_explicit_uniform_location,
#endif
#if GL_ARB_fragment_coord_conventions
  __GLEW_ARB_fragment_coord_conventions,
#endif
#if GL_ARB_fragment_layer_viewport
  __GLEW_ARB_fragment_layer_viewport,
#endif
#if GL_ARB_fragment_program
  __GLEW_ARB_fragment_program,
#endif
#if GL_ARB_fragment_program_shadow
  __GLEW_ARB_fragment_program_shadow,
#endif
#if GL_ARB_fragment_shader
  __GLEW_ARB_fragment_shader,
#endif
#if GL_ARB_fragment_shader_interlock
  __GLEW_ARB_fragment_shader_interlock,
#endif
#if GL_ARB_framebuffer_no_attachments
  __GLEW_ARB_framebuffer_no_attachments,
#endif
#if GL_ARB_framebuffer_object
  __GLEW_ARB_framebuffer_object,
#endif
#if GL_ARB_framebuffer_sRGB
  __GLEW_ARB_framebuffer_sRGB,
#endif
#if GL_ARB_geometry_shader4
  __GLEW_ARB_geometry_shader4,
#endif
#if GL_ARB_get_program_binary
  __GLEW_ARB_get_program_binary,
#endif
#if GL_ARB_get_texture_sub_image
  __GLEW_ARB_get_texture_sub_image,
#endif
#if GL_ARB_gl_spirv
  __GLEW_ARB_gl_spirv,
#endif
#if GL_ARB_gpu_shader5
  __GLEW_ARB_gpu_shader5,
#endif
#if GL_ARB_gpu_shader_fp64
  __GLEW_ARB_gpu_shader_fp64,
#endif
#if GL_ARB_gpu_shader_int64
  __GLEW_ARB_gpu_shader_int64,
#endif
#if GL_ARB_half_float_pixel
  __GLEW_ARB_half_float_pixel,
#endif
#if GL_ARB_half_float_vertex
  __GLEW_ARB_half_float_vertex,
#endif
#if GL_ARB_imaging
  __GLEW_ARB_imaging,
#endif
#if GL_ARB_indirect_parameters
  __GLEW_ARB_indirect_parameters,
#endif
#if GL_ARB_instanced_arrays
  __GLEW_ARB_instanced_arrays,
#endif
#if GL_ARB_internalformat_query
  __GLEW_ARB_internalformat_query,
#endif
#if GL_ARB_internalformat_query2
  __GLEW_ARB_internalformat_query2,
#endif
#if GL_ARB_invalidate_subdata
  __GLEW_ARB_invalidate_subdata,
#endif
#if GL_ARB_map_buffer_alignment
  __GLEW_ARB_map_buffer_alignment,
#endif
#if GL_ARB_map_buffer_range
  __GLEW_ARB_map_buffer_range,
#endif
#if GL_ARB_matrix_palette
  __GLEW_ARB_matrix_palette,
#endif
#if GL_ARB_multi_bind
  __GLEW_ARB_multi_bind,
#endif
#if GL_ARB_multi_draw_indirect
  __GLEW_ARB_multi_draw_indirect,
#endif
#if GL_ARB_multisample
  __GLEW_ARB_multisample,
#endif
#if GL_ARB_multitexture
  __GLEW_ARB_multitexture,
#endif
#if GL_ARB_occlusion_query
  __GLEW_ARB_occlusion_query,
#endif
#if GL_ARB_occlusion_query2
  __GLEW_ARB_occlusion_query2,
#endif
#if GL_ARB_parallel_shader_compile
  __GLEW_ARB_parallel_shader_compile,
#endif
#if GL_ARB_pipeline_statistics_query
  __GLEW_ARB_pipeline_statistics_query,
#endif
#if GL_ARB_pixel_buffer_object
  __GLEW_ARB_pixel_buffer_object,
#endif
#if GL_ARB_point_parameters
  __GLEW_ARB_point_parameters,
#endif
#if GL_ARB_point_sprite
  __GLEW_ARB_point_sprite,
#endif
#if GL_ARB_polygon_offset_clamp
  __GLEW_ARB_polygon_offset_clamp,
#endif
#if GL_ARB_post_depth_coverage
  __GLEW_ARB_post_depth_coverage,
#endif
#if GL_ARB_program_interface_query
  __GLEW_ARB_program_interface_query,
#endif
#if GL_ARB_provoking_vertex
  __GLEW_ARB_provoking_vertex,
#endif
#if GL_ARB_query_buffer_object
  __GLEW_ARB_query_buffer_object,
#endif
#if GL_ARB_robust_buffer_access_behavior
  __GLEW_ARB_robust_buffer_access_behavior,
#endif
#if GL_ARB_robustness
  __GLEW_ARB_robustness,
#endif
#if GL_ARB_robustness_application_isolation
  __GLEW_ARB_robustness_application_isolation,
#endif
#if GL_ARB_robustness_share_group_isolation
  __GLEW_ARB_robustness_share_group_isolation,
#endif
#if GL_ARB_sample_locations
  __GLEW_ARB_sample_locations,
#endif
#if GL_ARB_sample_shading
  __GLEW_ARB_sample_shading,
#endif
#if GL_ARB_sampler_objects
  __GLEW_ARB_sampler_objects,
#endif
#if GL_ARB_seamless_cube_map
  __GLEW_ARB_seamless_cube_map,
#endif
#if GL_ARB_seamless_cubemap_per_texture
  __GLEW_ARB_seamless_cubemap_per_texture,
#endif
#if GL_ARB_separate_shader_objects
  __GLEW_ARB_separate_shader_objects,
#endif
#if GL_ARB_shader_atomic_counter_ops
  __GLEW_ARB_shader_atomic_counter_ops,
#endif
#if GL_ARB_shader_atomic_counters
  __GLEW_ARB_shader_atomic_counters,
#endif
#if GL_ARB_shader_ballot
  __GLEW_ARB_shader_ballot,
#endif
#if GL_ARB_shader_bit_encoding
  __GLEW_ARB_shader_bit_encoding,
#endif
#if GL_ARB_shader_clock
  __GLEW_ARB_shader_clock,
#endif
#if GL_ARB_shader_draw_parameters
  __GLEW_ARB_shader_draw_parameters,
#endif
#if GL_ARB_shader_group_vote
  __GLEW_ARB_shader_group_vote,
#endif
#if GL_ARB_shader_image_load_store
  __GLEW_ARB_shader_image_load_store,
#endif
#if GL_ARB_shader_image_size
  __GLEW_ARB_shader_image_size,
#endif
#if GL_ARB_shader_objects
  __GLEW_ARB_shader_objects,
#endif
#if GL_ARB_shader_precision
  __GLEW_ARB_shader_precision,
#endif
#if GL_ARB_shader_stencil_export
  __GLEW_ARB_shader_stencil_export,
#endif
#if GL_ARB_shader_storage_buffer_object
  __GLEW_ARB_shader_storage_buffer_object,
#endif
#if GL_ARB_shader_subroutine
  __GLEW_ARB_shader_subroutine,
#endif
#if GL_ARB_shader_texture_image_samples
  __GLEW_ARB_shader_texture_image_samples,
#endif
#if GL_ARB_shader_texture_lod
  __GLEW_ARB_shader_texture_lod,
#endif
#if GL_ARB_shader_viewport_layer_array
  __GLEW_ARB_shader_viewport_layer_array,
#endif
#if GL_ARB_shading_language_100
  __GLEW_ARB_shading_language_100,
#endif
#if GL_ARB_shading_language_420pack
  __GLEW_ARB_shading_language_420pack,
#endif
#if GL_ARB_shading_language_include
  __GLEW_ARB_shading_language_include,
#endif
#if GL_ARB_shading_language_packing
  __GLEW_ARB_shading_language_packing,
#endif
#if GL_ARB_shadow
  __GLEW_ARB_shadow,
#endif
#if GL_ARB_shadow_ambient
  __GLEW_ARB_shadow_ambient,
#endif
#if GL_ARB_sparse_buffer
  __GLEW_ARB_sparse_buffer,
#endif
#if GL_ARB_sparse_texture
  __GLEW_ARB_sparse_texture,
#endif
#if GL_ARB_sparse_texture2
  __GLEW_ARB_sparse_texture2,
#endif
#if GL_ARB_sparse_texture_clamp
  __GLEW_ARB_sparse_texture_clamp,
#endif
#if GL_ARB_spirv_extensions
  __GLEW_ARB_spirv_extensions,
#endif
#if GL_ARB_stencil_texturing
  __GLEW_ARB_stencil_texturing,
#endif
#if GL_ARB_sync
  __GLEW_ARB_sync,
#endif
#if GL_ARB_tessellation_shader
  __GLEW_ARB_tessellation_shader,
#endif
#if GL_ARB_texture_barrier
  __GLEW_ARB_texture_barrier,
#endif
#if GL_ARB_texture_border_clamp
  __GLEW_ARB_texture_border_clamp,
#endif
#if GL_ARB_texture_buffer_object
  __GLEW_ARB_texture_buffer_object,
#endif
#if GL_ARB_texture_buffer_object_rgb32
  __GLEW_ARB_texture_buffer_object_rgb32,
#endif
#if GL_ARB_texture_buffer_range
  __GLEW_ARB_texture_buffer_range,
#endif
#if GL_ARB_texture_compression
  __GLEW_ARB_texture_compression,
#endif
#if GL_ARB_texture_compression_bptc
  __GLEW_ARB_texture_compression_bptc,
#endif
#if GL_ARB_texture_compression_rgtc
  __GLEW_ARB_texture_compression_rgtc,
#endif
#if GL_ARB_texture_cube_map
  __GLEW_ARB_texture_cube_map,
#endif
#if GL_ARB_texture_cube_map_array
  __GLEW_ARB_texture_cube_map_array,
#endif
#if GL_ARB_texture_env_add
  __GLEW_ARB_texture_env_add,
#endif
#if GL_ARB_texture_env_combine
  __GLEW_ARB_texture_env_combine,
#endif
#if GL_ARB_texture_env_crossbar
  __GLEW_ARB_texture_env_crossbar,
#endif
#if GL_ARB_texture_env_dot3
  __GLEW_ARB_texture_env_dot3,
#endif
#if GL_ARB_texture_filter_anisotropic
  __GLEW_ARB_texture_filter_anisotropic,
#endif
#if GL_ARB_texture_filter_minmax
  __GLEW_ARB_texture_filter_minmax,
#endif
#if GL_ARB_texture_float
  __GLEW_ARB_texture_float,
#endif
#if GL_ARB_texture_gather
  __GLEW_ARB_texture_gather,
#endif
#if GL_ARB_texture_mirror_clamp_to_edge
  __GLEW_ARB_texture_mirror_clamp_to_edge,
#endif
#if GL_ARB_texture_mirrored_repeat
  __GLEW_ARB_texture_mirrored_repeat,
#endif
#if GL_ARB_texture_multisample
  __GLEW_ARB_texture_multisample,
#endif
#if GL_ARB_texture_non_power_of_two
  __GLEW_ARB_texture_non_power_of_two,
#endif
#if GL_ARB_texture_query_levels
  __GLEW_ARB_texture_query_levels,
#endif
#if GL_ARB_texture_query_lod
  __GLEW_ARB_texture_query_lod,
#endif
#if GL_ARB_texture_rectangle
  __GLEW_ARB_texture_rectangle,
#endif
#if GL_ARB_texture_rg
  __GLEW_ARB_texture_rg,
#endif
#if GL_ARB_texture_rgb10_a2ui
  __GLEW_ARB_texture_rgb10_a2ui,
#endif
#if GL_ARB_texture_stencil8
  __GLEW_ARB_texture_stencil8,
#endif
#if GL_ARB_texture_storage
  __GLEW_ARB_texture_storage,
#endif
#if GL_ARB_texture_storage_multisample
  __GLEW_ARB_texture_storage_multisample,
#endif
#if GL_ARB_texture_swizzle
  __GLEW_ARB_texture_swizzle,
#endif
#if GL_ARB_texture_view
  __GLEW_ARB_texture_view,
#endif
#if GL_ARB_timer_query
  __GLEW_ARB_timer_query,
#endif
#if GL_ARB_transform_feedback2
  __GLEW_ARB_transform_feedback2,
#endif
#if GL_ARB_transform_feedback3
  __GLEW_ARB_transform_feedback3,
#endif
#if GL_ARB_transform_feedback_instanced
  __GLEW_ARB_transform_feedback_instanced,
#endif
#if GL_ARB_transform_feedback_overflow_query
  __GLEW_ARB_transform_feedback_overflow_query,
#endif
#if GL_ARB_transpose_matrix
  __GLEW_ARB_transpose_matrix,
#endif
#if GL_ARB_uniform_buffer_object
  __GLEW_ARB_uniform_buffer_object,
#endif
#if GL_ARB_vertex_array_bgra
  __GLEW_ARB_vertex_array_bgra,
#endif
#if GL_ARB_vertex_array_object
  __GLEW_ARB_vertex_array_object,
#endif
#if GL_ARB_vertex_attrib_64bit
  __GLEW_ARB_vertex_attrib_64bit,
#endif
#if GL_ARB_vertex_attrib_binding
  __GLEW_ARB_vertex_attrib_binding,
#endif
#if GL_ARB_vertex_blend
  __GLEW_ARB_vertex_blend,
#endif
#if GL_ARB_vertex_buffer_object
  __GLEW_ARB_vertex_buffer_object,
#endif
#if GL_ARB_vertex_program
  __GLEW_ARB_vertex_program,
#endif
#if GL_ARB_vertex_shader
  __GLEW_ARB_vertex_shader,
#endif
#if GL_ARB_vertex_type_10f_11f_11f_rev
  __GLEW_ARB_vertex_type_10f_11f_11f_rev,
#endif
#if GL_ARB_vertex_type_2_10_10_10_rev
  __GLEW_ARB_vertex_type_2_10_10_10_rev,
#endif
#if GL_ARB_viewport_array
  __GLEW_ARB_viewport_array,
#endif
#if GL_ARB_window_pos
  __GLEW_ARB_window_pos,
#endif
#if GL_ARM_mali_program_binary
  __GLEW_ARM_mali_program_binary,
#endif
#if GL_ARM_mali_shader_binary
  __GLEW_ARM_mali_shader_binary,
#endif
#if GL_ARM_rgba8
  __GLEW_ARM_rgba8,
#endif
#if GL_ARM_shader_core_properties
  __GLEW_ARM_shader_core_properties,
#endif
#if GL_ARM_shader_framebuffer_fetch
  __GLEW_ARM_shader_framebuffer_fetch,
#endif
#if GL_ARM_shader_framebuffer_fetch_depth_stencil
  __GLEW_ARM_shader_framebuffer_fetch_depth_stencil,
#endif
#if GL_ARM_texture_unnormalized_coordinates
  __GLEW_ARM_texture_unnormalized_coordinates,
#endif
#if GL_ATIX_point_sprites
  __GLEW_ATIX_point_sprites,
#endif
#if GL_ATIX_texture_env_combine3
  __GLEW_ATIX_texture_env_combine3,
#endif
#if GL_ATIX_texture_env_route
  __GLEW_ATIX_texture_env_route,
#endif
#if GL_ATIX_vertex_shader_output_point_size
  __GLEW_ATIX_vertex_shader_output_point_size,
#endif
#if GL_ATI_draw_buffers
  __GLEW_ATI_draw_buffers,
#endif
#if GL_ATI_element_array
  __GLEW_ATI_element_array,
#endif
#if GL_ATI_envmap_bumpmap
  __GLEW_ATI_envmap_bumpmap,
#endif
#if GL_ATI_fragment_shader
  __GLEW_ATI_fragment_shader,
#endif
#if GL_ATI_map_object_buffer
  __GLEW_ATI_map_object_buffer,
#endif
#if GL_ATI_meminfo
  __GLEW_ATI_meminfo,
#endif
#if GL_ATI_pn_triangles
  __GLEW_ATI_pn_triangles,
#endif
#if GL_ATI_separate_stencil
  __GLEW_ATI_separate_stencil,
#endif
#if GL_ATI_shader_texture_lod
  __GLEW_ATI_shader_texture_lod,
#endif
#if GL_ATI_text_fragment_shader
  __GLEW_ATI_text_fragment_shader,
#endif
#if GL_ATI_texture_compression_3dc
  __GLEW_ATI_texture_compression_3dc,
#endif
#if GL_ATI_texture_env_combine3
  __GLEW_ATI_texture_env_combine3,
#endif
#if GL_ATI_texture_float
  __GLEW_ATI_texture_float,
#endif
#if GL_ATI_texture_mirror_once
  __GLEW_ATI_texture_mirror_once,
#endif
#if GL_ATI_vertex_array_object
  __GLEW_ATI_vertex_array_object,
#endif
#if GL_ATI_vertex_attrib_array_object
  __GLEW_ATI_vertex_attrib_array_object,
#endif
#if GL_ATI_vertex_streams
  __GLEW_ATI_vertex_streams,
#endif
#if GL_DMP_program_binary
  __GLEW_DMP_program_binary,
#endif
#if GL_DMP_shader_binary
  __GLEW_DMP_shader_binary,
#endif
#if GL_EXT_422_pixels
  __GLEW_EXT_422_pixels,
#endif
#if GL_EXT_Cg_shader
  __GLEW_EXT_Cg_shader,
#endif
#if GL_EXT_EGL_image_array
  __GLEW_EXT_EGL_image_array,
#endif
#if GL_EXT_EGL_image_external_wrap_modes
  __GLEW_EXT_EGL_image_external_wrap_modes,
#endif
#if GL_EXT_EGL_image_storage
  __GLEW_EXT_EGL_image_storage,
#endif
#if GL_EXT_EGL_image_storage_compression
  __GLEW_EXT_EGL_image_storage_compression,
#endif
#if GL_EXT_EGL_sync
  __GLEW_EXT_EGL_sync,
#endif
#if GL_EXT_YUV_target
  __GLEW_EXT_YUV_target,
#endif
#if GL_EXT_abgr
  __GLEW_EXT_abgr,
#endif
#if GL_EXT_base_instance
  __GLEW_EXT_base_instance,
#endif
#if GL_EXT_bgra
  __GLEW_EXT_bgra,
#endif
#if GL_EXT_bindable_uniform
  __GLEW_EXT_bindable_uniform,
#endif
#if GL_EXT_blend_color
  __GLEW_EXT_blend_color,
#endif
#if GL_EXT_blend_equation_separate
  __GLEW_EXT_blend_equation_separate,
#endif
#if GL_EXT_blend_func_extended
  __GLEW_EXT_blend_func_extended,
#endif
#if GL_EXT_blend_func_separate
  __GLEW_EXT_blend_func_separate,
#endif
#if GL_EXT_blend_logic_op
  __GLEW_EXT_blend_logic_op,
#endif
#if GL_EXT_blend_minmax
  __GLEW_EXT_blend_minmax,
#endif
#if GL_EXT_blend_subtract
  __GLEW_EXT_blend_subtract,
#endif
#if GL_EXT_buffer_storage
  __GLEW_EXT_buffer_storage,
#endif
#if GL_EXT_clear_texture
  __GLEW_EXT_clear_texture,
#endif
#if GL_EXT_clip_control
  __GLEW_EXT_clip_control,
#endif
#if GL_EXT_clip_cull_distance
  __GLEW_EXT_clip_cull_distance,
#endif
#if GL_EXT_clip_volume_hint
  __GLEW_EXT_clip_volume_hint,
#endif
#if GL_EXT_cmyka
  __GLEW_EXT_cmyka,
#endif
#if GL_EXT_color_buffer_float
  __GLEW_EXT_color_buffer_float,
#endif
#if GL_EXT_color_buffer_half_float
  __GLEW_EXT_color_buffer_half_float,
#endif
#if GL_EXT_color_subtable
  __GLEW_EXT_color_subtable,
#endif
#if GL_EXT_compiled_vertex_array
  __GLEW_EXT_compiled_vertex_array,
#endif
#if GL_EXT_compressed_ETC1_RGB8_sub_texture
  __GLEW_EXT_compressed_ETC1_RGB8_sub_texture,
#endif
#if GL_EXT_conservative_depth
  __GLEW_EXT_conservative_depth,
#endif
#if GL_EXT_convolution
  __GLEW_EXT_convolution,
#endif
#if GL_EXT_coordinate_frame
  __GLEW_EXT_coordinate_frame,
#endif
#if GL_EXT_copy_image
  __GLEW_EXT_copy_image,
#endif
#if GL_EXT_copy_texture
  __GLEW_EXT_copy_texture,
#endif
#if GL_EXT_cull_vertex
  __GLEW_EXT_cull_vertex,
#endif
#if GL_EXT_debug_label
  __GLEW_EXT_debug_label,
#endif
#if GL_EXT_debug_marker
  __GLEW_EXT_debug_marker,
#endif
#if GL_EXT_depth_bounds_test
  __GLEW_EXT_depth_bounds_test,
#endif
#if GL_EXT_depth_clamp
  __GLEW_EXT_depth_clamp,
#endif
#if GL_EXT_direct_state_access
  __GLEW_EXT_direct_state_access,
#endif
#if GL_EXT_discard_framebuffer
  __GLEW_EXT_discard_framebuffer,
#endif
#if GL_EXT_disjoint_timer_query
  __GLEW_EXT_disjoint_timer_query,
#endif
#if GL_EXT_draw_buffers
  __GLEW_EXT_draw_buffers,
#endif
#if GL_EXT_draw_buffers2
  __GLEW_EXT_draw_buffers2,
#endif
#if GL_EXT_draw_buffers_indexed
  __GLEW_EXT_draw_buffers_indexed,
#endif
#if GL_EXT_draw_elements_base_vertex
  __GLEW_EXT_draw_elements_base_vertex,
#endif
#if GL_EXT_draw_instanced
  __GLEW_EXT_draw_instanced,
#endif
#if GL_EXT_draw_range_elements
  __GLEW_EXT_draw_range_elements,
#endif
#if GL_EXT_draw_transform_feedback
  __GLEW_EXT_draw_transform_feedback,
#endif
#if GL_EXT_external_buffer
  __GLEW_EXT_external_buffer,
#endif
#if GL_EXT_float_blend
  __GLEW_EXT_float_blend,
#endif
#if GL_EXT_fog_coord
  __GLEW_EXT_fog_coord,
#endif
#if GL_EXT_frag_depth
  __GLEW_EXT_frag_depth,
#endif
#if GL_EXT_fragment_lighting
  __GLEW_EXT_fragment_lighting,
#endif
#if GL_EXT_fragment_shading_rate
  __GLEW_EXT_fragment_shading_rate,
#endif
#if GL_EXT_fragment_shading_rate_attachment
  __GLEW_EXT_fragment_shading_rate_attachment,
#endif
#if GL_EXT_fragment_shading_rate_primitive
  __GLEW_EXT_fragment_shading_rate_primitive,
#endif
#if GL_EXT_framebuffer_blit
  __GLEW_EXT_framebuffer_blit,
#endif
#if GL_EXT_framebuffer_blit_layers
  __GLEW_EXT_framebuffer_blit_layers,
#endif
#if GL_EXT_framebuffer_multisample
  __GLEW_EXT_framebuffer_multisample,
#endif
#if GL_EXT_framebuffer_multisample_blit_scaled
  __GLEW_EXT_framebuffer_multisample_blit_scaled,
#endif
#if GL_EXT_framebuffer_object
  __GLEW_EXT_framebuffer_object,
#endif
#if GL_EXT_framebuffer_sRGB
  __GLEW_EXT_framebuffer_sRGB,
#endif
#if GL_EXT_geometry_point_size
  __GLEW_EXT_geometry_point_size,
#endif
#if GL_EXT_geometry_shader
  __GLEW_EXT_geometry_shader,
#endif
#if GL_EXT_geometry_shader4
  __GLEW_EXT_geometry_shader4,
#endif
#if GL_EXT_gpu_program_parameters
  __GLEW_EXT_gpu_program_parameters,
#endif
#if GL_EXT_gpu_shader4
  __GLEW_EXT_gpu_shader4,
#endif
#if GL_EXT_gpu_shader5
  __GLEW_EXT_gpu_shader5,
#endif
#if GL_EXT_histogram
  __GLEW_EXT_histogram,
#endif
#if GL_EXT_index_array_formats
  __GLEW_EXT_index_array_formats,
#endif
#if GL_EXT_index_func
  __GLEW_EXT_index_func,
#endif
#if GL_EXT_index_material
  __GLEW_EXT_index_material,
#endif
#if GL_EXT_index_texture
  __GLEW_EXT_index_texture,
#endif
#if GL_EXT_instanced_arrays
  __GLEW_EXT_instanced_arrays,
#endif
#if GL_EXT_light_texture
  __GLEW_EXT_light_texture,
#endif
#if GL_EXT_map_buffer_range
  __GLEW_EXT_map_buffer_range,
#endif
#if GL_EXT_memory_object
  __GLEW_EXT_memory_object,
#endif
#if GL_EXT_memory_object_fd
  __GLEW_EXT_memory_object_fd,
#endif
#if GL_EXT_memory_object_win32
  __GLEW_EXT_memory_object_win32,
#endif
#if GL_EXT_mesh_shader
  __GLEW_EXT_mesh_shader,
#endif
#if GL_EXT_misc_attribute
  __GLEW_EXT_misc_attribute,
#endif
#if GL_EXT_multi_draw_arrays
  __GLEW_EXT_multi_draw_arrays,
#endif
#if GL_EXT_multi_draw_indirect
  __GLEW_EXT_multi_draw_indirect,
#endif
#if GL_EXT_multiple_textures
  __GLEW_EXT_multiple_textures,
#endif
#if GL_EXT_multisample
  __GLEW_EXT_multisample,
#endif
#if GL_EXT_multisample_compatibility
  __GLEW_EXT_multisample_compatibility,
#endif
#if GL_EXT_multisampled_render_to_texture
  __GLEW_EXT_multisampled_render_to_texture,
#endif
#if GL_EXT_multisampled_render_to_texture2
  __GLEW_EXT_multisampled_render_to_texture2,
#endif
#if GL_EXT_multiview_draw_buffers
  __GLEW_EXT_multiview_draw_buffers,
#endif
#if GL_EXT_multiview_tessellation_geometry_shader
  __GLEW_EXT_multiview_tessellation_geometry_shader,
#endif
#if GL_EXT_multiview_texture_multisample
  __GLEW_EXT_multiview_texture_multisample,
#endif
#if GL_EXT_multiview_timer_query
  __GLEW_EXT_multiview_timer_query,
#endif
#if GL_EXT_occlusion_query_boolean
  __GLEW_EXT_occlusion_query_boolean,
#endif
#if GL_EXT_packed_depth_stencil
  __GLEW_EXT_packed_depth_stencil,
#endif
#if GL_EXT_packed_float
  __GLEW_EXT_packed_float,
#endif
#if GL_EXT_packed_pixels
  __GLEW_EXT_packed_pixels,
#endif
#if GL_EXT_paletted_texture
  __GLEW_EXT_paletted_texture,
#endif
#if GL_EXT_pixel_buffer_object
  __GLEW_EXT_pixel_buffer_object,
#endif
#if GL_EXT_pixel_transform
  __GLEW_EXT_pixel_transform,
#endif
#if GL_EXT_pixel_transform_color_table
  __GLEW_EXT_pixel_transform_color_table,
#endif
#if GL_EXT_point_parameters
  __GLEW_EXT_point_parameters,
#endif
#if GL_EXT_polygon_offset
  __GLEW_EXT_polygon_offset,
#endif
#if GL_EXT_polygon_offset_clamp
  __GLEW_EXT_polygon_offset_clamp,
#endif
#if GL_EXT_post_depth_coverage
  __GLEW_EXT_post_depth_coverage,
#endif
#if GL_EXT_primitive_bounding_box
  __GLEW_EXT_primitive_bounding_box,
#endif
#if GL_EXT_protected_textures
  __GLEW_EXT_protected_textures,
#endif
#if GL_EXT_provoking_vertex
  __GLEW_EXT_provoking_vertex,
#endif
#if GL_EXT_pvrtc_sRGB
  __GLEW_EXT_pvrtc_sRGB,
#endif
#if GL_EXT_raster_multisample
  __GLEW_EXT_raster_multisample,
#endif
#if GL_EXT_read_format_bgra
  __GLEW_EXT_read_format_bgra,
#endif
#if GL_EXT_render_snorm
  __GLEW_EXT_render_snorm,
#endif
#if GL_EXT_rescale_normal
  __GLEW_EXT_rescale_normal,
#endif
#if GL_EXT_robustness
  __GLEW_EXT_robustness,
#endif
#if GL_EXT_sRGB
  __GLEW_EXT_sRGB,
#endif
#if GL_EXT_sRGB_write_control
  __GLEW_EXT_sRGB_write_control,
#endif
#if GL_EXT_scene_marker
  __GLEW_EXT_scene_marker,
#endif
#if GL_EXT_secondary_color
  __GLEW_EXT_secondary_color,
#endif
#if GL_EXT_semaphore
  __GLEW_EXT_semaphore,
#endif
#if GL_EXT_semaphore_fd
  __GLEW_EXT_semaphore_fd,
#endif
#if GL_EXT_semaphore_win32
  __GLEW_EXT_semaphore_win32,
#endif
#if GL_EXT_separate_depth_stencil
  __GLEW_EXT_separate_depth_stencil,
#endif
#if GL_EXT_separate_shader_objects
  __GLEW_EXT_separate_shader_objects,
#endif
#if GL_EXT_separate_specular_color
  __GLEW_EXT_separate_specular_color,
#endif
#if GL_EXT_shader_clock
  __GLEW_EXT_shader_clock,
#endif
#if GL_EXT_shader_framebuffer_fetch
  __GLEW_EXT_shader_framebuffer_fetch,
#endif
#if GL_EXT_shader_framebuffer_fetch_non_coherent
  __GLEW_EXT_shader_framebuffer_fetch_non_coherent,
#endif
#if GL_EXT_shader_group_vote
  __GLEW_EXT_shader_group_vote,
#endif
#if GL_EXT_shader_image_load_formatted
  __GLEW_EXT_shader_image_load_formatted,
#endif
#if GL_EXT_shader_image_load_store
  __GLEW_EXT_shader_image_load_store,
#endif
#if GL_EXT_shader_implicit_conversions
  __GLEW_EXT_shader_implicit_conversions,
#endif
#if GL_EXT_shader_integer_mix
  __GLEW_EXT_shader_integer_mix,
#endif
#if GL_EXT_shader_io_blocks
  __GLEW_EXT_shader_io_blocks,
#endif
#if GL_EXT_shader_non_constant_global_initializers
  __GLEW_EXT_shader_non_constant_global_initializers,
#endif
#if GL_EXT_shader_pixel_local_storage
  __GLEW_EXT_shader_pixel_local_storage,
#endif
#if GL_EXT_shader_pixel_local_storage2
  __GLEW_EXT_shader_pixel_local_storage2,
#endif
#if GL_EXT_shader_realtime_clock
  __GLEW_EXT_shader_realtime_clock,
#endif
#if GL_EXT_shader_samples_identical
  __GLEW_EXT_shader_samples_identical,
#endif
#if GL_EXT_shader_texture_lod
  __GLEW_EXT_shader_texture_lod,
#endif
#if GL_EXT_shader_texture_samples
  __GLEW_EXT_shader_texture_samples,
#endif
#if GL_EXT_shadow_funcs
  __GLEW_EXT_shadow_funcs,
#endif
#if GL_EXT_shadow_samplers
  __GLEW_EXT_shadow_samplers,
#endif
#if GL_EXT_shared_texture_palette
  __GLEW_EXT_shared_texture_palette,
#endif
#if GL_EXT_sparse_texture
  __GLEW_EXT_sparse_texture,
#endif
#if GL_EXT_sparse_texture2
  __GLEW_EXT_sparse_texture2,
#endif
#if GL_EXT_static_vertex_array
  __GLEW_EXT_static_vertex_array,
#endif
#if GL_EXT_stencil_clear_tag
  __GLEW_EXT_stencil_clear_tag,
#endif
#if GL_EXT_stencil_two_side
  __GLEW_EXT_stencil_two_side,
#endif
#if GL_EXT_stencil_wrap
  __GLEW_EXT_stencil_wrap,
#endif
#if GL_EXT_subtexture
  __GLEW_EXT_subtexture,
#endif
#if GL_EXT_tessellation_point_size
  __GLEW_EXT_tessellation_point_size,
#endif
#if GL_EXT_tessellation_shader
  __GLEW_EXT_tessellation_shader,
#endif
#if GL_EXT_texture
  __GLEW_EXT_texture,
#endif
#if GL_EXT_texture3D
  __GLEW_EXT_texture3D,
#endif
#if GL_EXT_texture_array
  __GLEW_EXT_texture_array,
#endif
#if GL_EXT_texture_border_clamp
  __GLEW_EXT_texture_border_clamp,
#endif
#if GL_EXT_texture_buffer
  __GLEW_EXT_texture_buffer,
#endif
#if GL_EXT_texture_buffer_object
  __GLEW_EXT_texture_buffer_object,
#endif
#if GL_EXT_texture_compression_astc_decode_mode
  __GLEW_EXT_texture_compression_astc_decode_mode,
#endif
#if GL_EXT_texture_compression_astc_decode_mode_rgb9e5
  __GLEW_EXT_texture_compression_astc_decode_mode_rgb9e5,
#endif
#if GL_EXT_texture_compression_bptc
  __GLEW_EXT_texture_compression_bptc,
#endif
#if GL_EXT_texture_compression_dxt1
  __GLEW_EXT_texture_compression_dxt1,
#endif
#if GL_EXT_texture_compression_latc
  __GLEW_EXT_texture_compression_latc,
#endif
#if GL_EXT_texture_compression_rgtc
  __GLEW_EXT_texture_compression_rgtc,
#endif
#if GL_EXT_texture_compression_s3tc
  __GLEW_EXT_texture_compression_s3tc,
#endif
#if GL_EXT_texture_compression_s3tc_srgb
  __GLEW_EXT_texture_compression_s3tc_srgb,
#endif
#if GL_EXT_texture_cube_map
  __GLEW_EXT_texture_cube_map,
#endif
#if GL_EXT_texture_cube_map_array
  __GLEW_EXT_texture_cube_map_array,
#endif
#if GL_EXT_texture_edge_clamp
  __GLEW_EXT_texture_edge_clamp,
#endif
#if GL_EXT_texture_env
  __GLEW_EXT_texture_env,
#endif
#if GL_EXT_texture_env_add
  __GLEW_EXT_texture_env_add,
#endif
#if GL_EXT_texture_env_combine
  __GLEW_EXT_texture_env_combine,
#endif
#if GL_EXT_texture_env_dot3
  __GLEW_EXT_texture_env_dot3,
#endif
#if GL_EXT_texture_filter_anisotropic
  __GLEW_EXT_texture_filter_anisotropic,
#endif
#if GL_EXT_texture_filter_minmax
  __GLEW_EXT_texture_filter_minmax,
#endif
#if GL_EXT_texture_format_BGRA8888
  __GLEW_EXT_texture_format_BGRA8888,
#endif
#if GL_EXT_texture_format_sRGB_override
  __GLEW_EXT_texture_format_sRGB_override,
#endif
#if GL_EXT_texture_integer
  __GLEW_EXT_texture_integer,
#endif
#if GL_EXT_texture_lod_bias
  __GLEW_EXT_texture_lod_bias,
#endif
#if GL_EXT_texture_mirror_clamp
  __GLEW_EXT_texture_mirror_clamp,
#endif
#if GL_EXT_texture_mirror_clamp_to_edge
  __GLEW_EXT_texture_mirror_clamp_to_edge,
#endif
#if GL_EXT_texture_norm16
  __GLEW_EXT_texture_norm16,
#endif
#if GL_EXT_texture_object
  __GLEW_EXT_texture_object,
#endif
#if GL_EXT_texture_perturb_normal
  __GLEW_EXT_texture_perturb_normal,
#endif
#if GL_EXT_texture_query_lod
  __GLEW_EXT_texture_query_lod,
#endif
#if GL_EXT_texture_rectangle
  __GLEW_EXT_texture_rectangle,
#endif
#if GL_EXT_texture_rg
  __GLEW_EXT_texture_rg,
#endif
#if GL_EXT_texture_sRGB
  __GLEW_EXT_texture_sRGB,
#endif
#if GL_EXT_texture_sRGB_R8
  __GLEW_EXT_texture_sRGB_R8,
#endif
#if GL_EXT_texture_sRGB_RG8
  __GLEW_EXT_texture_sRGB_RG8,
#endif
#if GL_EXT_texture_sRGB_decode
  __GLEW_EXT_texture_sRGB_decode,
#endif
#if GL_EXT_texture_shadow_lod
  __GLEW_EXT_texture_shadow_lod,
#endif
#if GL_EXT_texture_shared_exponent
  __GLEW_EXT_texture_shared_exponent,
#endif
#if GL_EXT_texture_snorm
  __GLEW_EXT_texture_snorm,
#endif
#if GL_EXT_texture_storage
  __GLEW_EXT_texture_storage,
#endif
#if GL_EXT_texture_storage_compression
  __GLEW_EXT_texture_storage_compression,
#endif
#if GL_EXT_texture_swizzle
  __GLEW_EXT_texture_swizzle,
#endif
#if GL_EXT_texture_type_2_10_10_10_REV
  __GLEW_EXT_texture_type_2_10_10_10_REV,
#endif
#if GL_EXT_texture_view
  __GLEW_EXT_texture_view,
#endif
#if GL_EXT_timer_query
  __GLEW_EXT_timer_query,
#endif
#if GL_EXT_transform_feedback
  __GLEW_EXT_transform_feedback,
#endif
#if GL_EXT_unpack_subimage
  __GLEW_EXT_unpack_subimage,
#endif
#if GL_EXT_vertex_array
  __GLEW_EXT_vertex_array,
#endif
#if GL_EXT_vertex_array_bgra
  __GLEW_EXT_vertex_array_bgra,
#endif
#if GL_EXT_vertex_array_setXXX
  __GLEW_EXT_vertex_array_setXXX,
#endif
#if GL_EXT_vertex_attrib_64bit
  __GLEW_EXT_vertex_attrib_64bit,
#endif
#if GL_EXT_vertex_shader
  __GLEW_EXT_vertex_shader,
#endif
#if GL_EXT_vertex_weighting
  __GLEW_EXT_vertex_weighting,
#endif
#if GL_EXT_win32_keyed_mutex
  __GLEW_EXT_win32_keyed_mutex,
#endif
#if GL_EXT_window_rectangles
  __GLEW_EXT_window_rectangles,
#endif
#if GL_EXT_x11_sync_object
  __GLEW_EXT_x11_sync_object,
#endif
#if GL_FJ_shader_binary_GCCSO
  __GLEW_FJ_shader_binary_GCCSO,
#endif
#if GL_GREMEDY_frame_terminator
  __GLEW_GREMEDY_frame_terminator,
#endif
#if GL_GREMEDY_string_marker
  __GLEW_GREMEDY_string_marker,
#endif
#if GL_HP_convolution_border_modes
  __GLEW_HP_convolution_border_modes,
#endif
#if GL_HP_image_transform
  __GLEW_HP_image_transform,
#endif
#if GL_HP_occlusion_test
  __GLEW_HP_occlusion_test,
#endif
#if GL_HP_texture_lighting
  __GLEW_HP_texture_lighting,
#endif
#if GL_HUAWEI_program_binary
  __GLEW_HUAWEI_program_binary,
#endif
#if GL_HUAWEI_shader_binary
  __GLEW_HUAWEI_shader_binary,
#endif
#if GL_IBM_cull_vertex
  __GLEW_IBM_cull_vertex,
#endif
#if GL_IBM_multimode_draw_arrays
  __GLEW_IBM_multimode_draw_arrays,
#endif
#if GL_IBM_rasterpos_clip
  __GLEW_IBM_rasterpos_clip,
#endif
#if GL_IBM_static_data
  __GLEW_IBM_static_data,
#endif
#if GL_IBM_texture_mirrored_repeat
  __GLEW_IBM_texture_mirrored_repeat,
#endif
#if GL_IBM_vertex_array_lists
  __GLEW_IBM_vertex_array_lists,
#endif
#if GL_IMG_bindless_texture
  __GLEW_IMG_bindless_texture,
#endif
#if GL_IMG_framebuffer_downsample
  __GLEW_IMG_framebuffer_downsample,
#endif
#if GL_IMG_multisampled_render_to_texture
  __GLEW_IMG_multisampled_render_to_texture,
#endif
#if GL_IMG_program_binary
  __GLEW_IMG_program_binary,
#endif
#if GL_IMG_pvric_end_to_end_signature
  __GLEW_IMG_pvric_end_to_end_signature,
#endif
#if GL_IMG_read_format
  __GLEW_IMG_read_format,
#endif
#if GL_IMG_shader_binary
  __GLEW_IMG_shader_binary,
#endif
#if GL_IMG_texture_compression_pvrtc
  __GLEW_IMG_texture_compression_pvrtc,
#endif
#if GL_IMG_texture_compression_pvrtc2
  __GLEW_IMG_texture_compression_pvrtc2,
#endif
#if GL_IMG_texture_env_enhanced_fixed_function
  __GLEW_IMG_texture_env_enhanced_fixed_function,
#endif
#if GL_IMG_texture_filter_cubic
  __GLEW_IMG_texture_filter_cubic,
#endif
#if GL_IMG_tile_region_protection
  __GLEW_IMG_tile_region_protection,
#endif
#if GL_INGR_color_clamp
  __GLEW_INGR_color_clamp,
#endif
#if GL_INGR_interlace_read
  __GLEW_INGR_interlace_read,
#endif
#if GL_INTEL_blackhole_render
  __GLEW_INTEL_blackhole_render,
#endif
#if GL_INTEL_conservative_rasterization
  __GLEW_INTEL_conservative_rasterization,
#endif
#if GL_INTEL_fragment_shader_ordering
  __GLEW_INTEL_fragment_shader_ordering,
#endif
#if GL_INTEL_framebuffer_CMAA
  __GLEW_INTEL_framebuffer_CMAA,
#endif
#if GL_INTEL_map_texture
  __GLEW_INTEL_map_texture,
#endif
#if GL_INTEL_parallel_arrays
  __GLEW_INTEL_parallel_arrays,
#endif
#if GL_INTEL_performance_query
  __GLEW_INTEL_performance_query,
#endif
#if GL_INTEL_shader_integer_functions2
  __GLEW_INTEL_shader_integer_functions2,
#endif
#if GL_INTEL_texture_scissor
  __GLEW_INTEL_texture_scissor,
#endif
#if GL_KHR_blend_equation_advanced
  __GLEW_KHR_blend_equation_advanced,
#endif
#if GL_KHR_blend_equation_advanced_coherent
  __GLEW_KHR_blend_equation_advanced_coherent,
#endif
#if GL_KHR_context_flush_control
  __GLEW_KHR_context_flush_control,
#endif
#if GL_KHR_debug
  __GLEW_KHR_debug,
#endif
#if GL_KHR_no_error
  __GLEW_KHR_no_error,
#endif
#if GL_KHR_parallel_shader_compile
  __GLEW_KHR_parallel_shader_compile,
#endif
#if GL_KHR_robust_buffer_access_behavior
  __GLEW_KHR_robust_buffer_access_behavior,
#endif
#if GL_KHR_robustness
  __GLEW_KHR_robustness,
#endif
#if GL_KHR_shader_subgroup
  __GLEW_KHR_shader_subgroup,
#endif
#if GL_KHR_texture_compression_astc_hdr
  __GLEW_KHR_texture_compression_astc_hdr,
#endif
#if GL_KHR_texture_compression_astc_ldr
  __GLEW_KHR_texture_compression_astc_ldr,
#endif
#if GL_KHR_texture_compression_astc_sliced_3d
  __GLEW_KHR_texture_compression_astc_sliced_3d,
#endif
#if GL_KTX_buffer_region
  __GLEW_KTX_buffer_region,
#endif
#if GL_MESAX_texture_stack
  __GLEW_MESAX_texture_stack,
#endif
#if GL_MESA_bgra
  __GLEW_MESA_bgra,
#endif
#if GL_MESA_framebuffer_flip_x
  __GLEW_MESA_framebuffer_flip_x,
#endif
#if GL_MESA_framebuffer_flip_y
  __GLEW_MESA_framebuffer_flip_y,
#endif
#if GL_MESA_framebuffer_swap_xy
  __GLEW_MESA_framebuffer_swap_xy,
#endif
#if GL_MESA_pack_invert
  __GLEW_MESA_pack_invert,
#endif
#if GL_MESA_program_binary_formats
  __GLEW_MESA_program_binary_formats,
#endif
#if GL_MESA_resize_buffers
  __GLEW_MESA_resize_buffers,
#endif
#if GL_MESA_shader_integer_functions
  __GLEW_MESA_shader_integer_functions,
#endif
#if GL_MESA_texture_const_bandwidth
  __GLEW_MESA_texture_const_bandwidth,
#endif
#if GL_MESA_tile_raster_order
  __GLEW_MESA_tile_raster_order,
#endif
#if GL_MESA_window_pos
  __GLEW_MESA_window_pos,
#endif
#if GL_MESA_ycbcr_texture
  __GLEW_MESA_ycbcr_texture,
#endif
#if GL_NVX_blend_equation_advanced_multi_draw_buffers
  __GLEW_NVX_blend_equation_advanced_multi_draw_buffers,
#endif
#if GL_NVX_conditional_render
  __GLEW_NVX_conditional_render,
#endif
#if GL_NVX_gpu_memory_info
  __GLEW_NVX_gpu_memory_info,
#endif
#if GL_NVX_gpu_multicast2
  __GLEW_NVX_gpu_multicast2,
#endif
#if GL_NVX_linked_gpu_multicast
  __GLEW_NVX_linked_gpu_multicast,
#endif
#if GL_NVX_progress_fence
  __GLEW_NVX_progress_fence,
#endif
#if GL_NV_3dvision_settings
  __GLEW_NV_3dvision_settings,
#endif
#if GL_NV_EGL_stream_consumer_external
  __GLEW_NV_EGL_stream_consumer_external,
#endif
#if GL_NV_alpha_to_coverage_dither_control
  __GLEW_NV_alpha_to_coverage_dither_control,
#endif
#if GL_NV_bgr
  __GLEW_NV_bgr,
#endif
#if GL_NV_bindless_multi_draw_indirect
  __GLEW_NV_bindless_multi_draw_indirect,
#endif
#if GL_NV_bindless_multi_draw_indirect_count
  __GLEW_NV_bindless_multi_draw_indirect_count,
#endif
#if GL_NV_bindless_texture
  __GLEW_NV_bindless_texture,
#endif
#if GL_NV_blend_equation_advanced
  __GLEW_NV_blend_equation_advanced,
#endif
#if GL_NV_blend_equation_advanced_coherent
  __GLEW_NV_blend_equation_advanced_coherent,
#endif
#if GL_NV_blend_minmax_factor
  __GLEW_NV_blend_minmax_factor,
#endif
#if GL_NV_blend_square
  __GLEW_NV_blend_square,
#endif
#if GL_NV_clip_space_w_scaling
  __GLEW_NV_clip_space_w_scaling,
#endif
#if GL_NV_command_list
  __GLEW_NV_command_list,
#endif
#if GL_NV_compute_program5
  __GLEW_NV_compute_program5,
#endif
#if GL_NV_compute_shader_derivatives
  __GLEW_NV_compute_shader_derivatives,
#endif
#if GL_NV_conditional_render
  __GLEW_NV_conditional_render,
#endif
#if GL_NV_conservative_raster
  __GLEW_NV_conservative_raster,
#endif
#if GL_NV_conservative_raster_dilate
  __GLEW_NV_conservative_raster_dilate,
#endif
#if GL_NV_conservative_raster_pre_snap
  __GLEW_NV_conservative_raster_pre_snap,
#endif
#if GL_NV_conservative_raster_pre_snap_triangles
  __GLEW_NV_conservative_raster_pre_snap_triangles,
#endif
#if GL_NV_conservative_raster_underestimation
  __GLEW_NV_conservative_raster_underestimation,
#endif
#if GL_NV_copy_buffer
  __GLEW_NV_copy_buffer,
#endif
#if GL_NV_copy_depth_to_color
  __GLEW_NV_copy_depth_to_color,
#endif
#if GL_NV_copy_image
  __GLEW_NV_copy_image,
#endif
#if GL_NV_deep_texture3D
  __GLEW_NV_deep_texture3D,
#endif
#if GL_NV_depth_buffer_float
  __GLEW_NV_depth_buffer_float,
#endif
#if GL_NV_depth_clamp
  __GLEW_NV_depth_clamp,
#endif
#if GL_NV_depth_nonlinear
  __GLEW_NV_depth_nonlinear,
#endif
#if GL_NV_depth_range_unclamped
  __GLEW_NV_depth_range_unclamped,
#endif
#if GL_NV_draw_buffers
  __GLEW_NV_draw_buffers,
#endif
#if GL_NV_draw_instanced
  __GLEW_NV_draw_instanced,
#endif
#if GL_NV_draw_texture
  __GLEW_NV_draw_texture,
#endif
#if GL_NV_draw_vulkan_image
  __GLEW_NV_draw_vulkan_image,
#endif
#if GL_NV_evaluators
  __GLEW_NV_evaluators,
#endif
#if GL_NV_explicit_attrib_location
  __GLEW_NV_explicit_attrib_location,
#endif
#if GL_NV_explicit_multisample
  __GLEW_NV_explicit_multisample,
#endif
#if GL_NV_fbo_color_attachments
  __GLEW_NV_fbo_color_attachments,
#endif
#if GL_NV_fence
  __GLEW_NV_fence,
#endif
#if GL_NV_fill_rectangle
  __GLEW_NV_fill_rectangle,
#endif
#if GL_NV_float_buffer
  __GLEW_NV_float_buffer,
#endif
#if GL_NV_fog_distance
  __GLEW_NV_fog_distance,
#endif
#if GL_NV_fragment_coverage_to_color
  __GLEW_NV_fragment_coverage_to_color,
#endif
#if GL_NV_fragment_program
  __GLEW_NV_fragment_program,
#endif
#if GL_NV_fragment_program2
  __GLEW_NV_fragment_program2,
#endif
#if GL_NV_fragment_program4
  __GLEW_NV_fragment_program4,
#endif
#if GL_NV_fragment_program_option
  __GLEW_NV_fragment_program_option,
#endif
#if GL_NV_fragment_shader_barycentric
  __GLEW_NV_fragment_shader_barycentric,
#endif
#if GL_NV_fragment_shader_interlock
  __GLEW_NV_fragment_shader_interlock,
#endif
#if GL_NV_framebuffer_blit
  __GLEW_NV_framebuffer_blit,
#endif
#if GL_NV_framebuffer_mixed_samples
  __GLEW_NV_framebuffer_mixed_samples,
#endif
#if GL_NV_framebuffer_multisample
  __GLEW_NV_framebuffer_multisample,
#endif
#if GL_NV_framebuffer_multisample_coverage
  __GLEW_NV_framebuffer_multisample_coverage,
#endif
#if GL_NV_generate_mipmap_sRGB
  __GLEW_NV_generate_mipmap_sRGB,
#endif
#if GL_NV_geometry_program4
  __GLEW_NV_geometry_program4,
#endif
#if GL_NV_geometry_shader4
  __GLEW_NV_geometry_shader4,
#endif
#if GL_NV_geometry_shader_passthrough
  __GLEW_NV_geometry_shader_passthrough,
#endif
#if GL_NV_gpu_multicast
  __GLEW_NV_gpu_multicast,
#endif
#if GL_NV_gpu_program4
  __GLEW_NV_gpu_program4,
#endif
#if GL_NV_gpu_program5
  __GLEW_NV_gpu_program5,
#endif
#if GL_NV_gpu_program5_mem_extended
  __GLEW_NV_gpu_program5_mem_extended,
#endif
#if GL_NV_gpu_program_fp64
  __GLEW_NV_gpu_program_fp64,
#endif
#if GL_NV_gpu_shader5
  __GLEW_NV_gpu_shader5,
#endif
#if GL_NV_half_float
  __GLEW_NV_half_float,
#endif
#if GL_NV_image_formats
  __GLEW_NV_image_formats,
#endif
#if GL_NV_instanced_arrays
  __GLEW_NV_instanced_arrays,
#endif
#if GL_NV_internalformat_sample_query
  __GLEW_NV_internalformat_sample_query,
#endif
#if GL_NV_light_max_exponent
  __GLEW_NV_light_max_exponent,
#endif
#if GL_NV_memory_attachment
  __GLEW_NV_memory_attachment,
#endif
#if GL_NV_memory_object_sparse
  __GLEW_NV_memory_object_sparse,
#endif
#if GL_NV_mesh_shader
  __GLEW_NV_mesh_shader,
#endif
#if GL_NV_multisample_coverage
  __GLEW_NV_multisample_coverage,
#endif
#if GL_NV_multisample_filter_hint
  __GLEW_NV_multisample_filter_hint,
#endif
#if GL_NV_non_square_matrices
  __GLEW_NV_non_square_matrices,
#endif
#if GL_NV_occlusion_query
  __GLEW_NV_occlusion_query,
#endif
#if GL_NV_pack_subimage
  __GLEW_NV_pack_subimage,
#endif
#if GL_NV_packed_depth_stencil
  __GLEW_NV_packed_depth_stencil,
#endif
#if GL_NV_packed_float
  __GLEW_NV_packed_float,
#endif
#if GL_NV_packed_float_linear
  __GLEW_NV_packed_float_linear,
#endif
#if GL_NV_parameter_buffer_object
  __GLEW_NV_parameter_buffer_object,
#endif
#if GL_NV_parameter_buffer_object2
  __GLEW_NV_parameter_buffer_object2,
#endif
#if GL_NV_path_rendering
  __GLEW_NV_path_rendering,
#endif
#if GL_NV_path_rendering_shared_edge
  __GLEW_NV_path_rendering_shared_edge,
#endif
#if GL_NV_pixel_buffer_object
  __GLEW_NV_pixel_buffer_object,
#endif
#if GL_NV_pixel_data_range
  __GLEW_NV_pixel_data_range,
#endif
#if GL_NV_platform_binary
  __GLEW_NV_platform_binary,
#endif
#if GL_NV_point_sprite
  __GLEW_NV_point_sprite,
#endif
#if GL_NV_polygon_mode
  __GLEW_NV_polygon_mode,
#endif
#if GL_NV_present_video
  __GLEW_NV_present_video,
#endif
#if GL_NV_primitive_restart
  __GLEW_NV_primitive_restart,
#endif
#if GL_NV_primitive_shading_rate
  __GLEW_NV_primitive_shading_rate,
#endif
#if GL_NV_query_resource_tag
  __GLEW_NV_query_resource_tag,
#endif
#if GL_NV_read_buffer
  __GLEW_NV_read_buffer,
#endif
#if GL_NV_read_buffer_front
  __GLEW_NV_read_buffer_front,
#endif
#if GL_NV_read_depth
  __GLEW_NV_read_depth,
#endif
#if GL_NV_read_depth_stencil
  __GLEW_NV_read_depth_stencil,
#endif
#if GL_NV_read_stencil
  __GLEW_NV_read_stencil,
#endif
#if GL_NV_register_combiners
  __GLEW_NV_register_combiners,
#endif
#if GL_NV_register_combiners2
  __GLEW_NV_register_combiners2,
#endif
#if GL_NV_representative_fragment_test
  __GLEW_NV_representative_fragment_test,
#endif
#if GL_NV_robustness_video_memory_purge
  __GLEW_NV_robustness_video_memory_purge,
#endif
#if GL_NV_sRGB_formats
  __GLEW_NV_sRGB_formats,
#endif
#if GL_NV_sample_locations
  __GLEW_NV_sample_locations,
#endif
#if GL_NV_sample_mask_override_coverage
  __GLEW_NV_sample_mask_override_coverage,
#endif
#if GL_NV_scissor_exclusive
  __GLEW_NV_scissor_exclusive,
#endif
#if GL_NV_shader_atomic_counters
  __GLEW_NV_shader_atomic_counters,
#endif
#if GL_NV_shader_atomic_float
  __GLEW_NV_shader_atomic_float,
#endif
#if GL_NV_shader_atomic_float64
  __GLEW_NV_shader_atomic_float64,
#endif
#if GL_NV_shader_atomic_fp16_vector
  __GLEW_NV_shader_atomic_fp16_vector,
#endif
#if GL_NV_shader_atomic_int64
  __GLEW_NV_shader_atomic_int64,
#endif
#if GL_NV_shader_buffer_load
  __GLEW_NV_shader_buffer_load,
#endif
#if GL_NV_shader_noperspective_interpolation
  __GLEW_NV_shader_noperspective_interpolation,
#endif
#if GL_NV_shader_storage_buffer_object
  __GLEW_NV_shader_storage_buffer_object,
#endif
#if GL_NV_shader_subgroup_partitioned
  __GLEW_NV_shader_subgroup_partitioned,
#endif
#if GL_NV_shader_texture_footprint
  __GLEW_NV_shader_texture_footprint,
#endif
#if GL_NV_shader_thread_group
  __GLEW_NV_shader_thread_group,
#endif
#if GL_NV_shader_thread_shuffle
  __GLEW_NV_shader_thread_shuffle,
#endif
#if GL_NV_shading_rate_image
  __GLEW_NV_shading_rate_image,
#endif
#if GL_NV_shadow_samplers_array
  __GLEW_NV_shadow_samplers_array,
#endif
#if GL_NV_shadow_samplers_cube
  __GLEW_NV_shadow_samplers_cube,
#endif
#if GL_NV_stereo_view_rendering
  __GLEW_NV_stereo_view_rendering,
#endif
#if GL_NV_tessellation_program5
  __GLEW_NV_tessellation_program5,
#endif
#if GL_NV_texgen_emboss
  __GLEW_NV_texgen_emboss,
#endif
#if GL_NV_texgen_reflection
  __GLEW_NV_texgen_reflection,
#endif
#if GL_NV_texture_array
  __GLEW_NV_texture_array,
#endif
#if GL_NV_texture_barrier
  __GLEW_NV_texture_barrier,
#endif
#if GL_NV_texture_border_clamp
  __GLEW_NV_texture_border_clamp,
#endif
#if GL_NV_texture_compression_latc
  __GLEW_NV_texture_compression_latc,
#endif
#if GL_NV_texture_compression_s3tc
  __GLEW_NV_texture_compression_s3tc,
#endif
#if GL_NV_texture_compression_s3tc_update
  __GLEW_NV_texture_compression_s3tc_update,
#endif
#if GL_NV_texture_compression_vtc
  __GLEW_NV_texture_compression_vtc,
#endif
#if GL_NV_texture_env_combine4
  __GLEW_NV_texture_env_combine4,
#endif
#if GL_NV_texture_expand_normal
  __GLEW_NV_texture_expand_normal,
#endif
#if GL_NV_texture_multisample
  __GLEW_NV_texture_multisample,
#endif
#if GL_NV_texture_npot_2D_mipmap
  __GLEW_NV_texture_npot_2D_mipmap,
#endif
#if GL_NV_texture_rectangle
  __GLEW_NV_texture_rectangle,
#endif
#if GL_NV_texture_rectangle_compressed
  __GLEW_NV_texture_rectangle_compressed,
#endif
#if GL_NV_texture_shader
  __GLEW_NV_texture_shader,
#endif
#if GL_NV_texture_shader2
  __GLEW_NV_texture_shader2,
#endif
#if GL_NV_texture_shader3
  __GLEW_NV_texture_shader3,
#endif
#if GL_NV_timeline_semaphore
  __GLEW_NV_timeline_semaphore,
#endif
#if GL_NV_transform_feedback
  __GLEW_NV_transform_feedback,
#endif
#if GL_NV_transform_feedback2
  __GLEW_NV_transform_feedback2,
#endif
#if GL_NV_uniform_buffer_std430_layout
  __GLEW_NV_uniform_buffer_std430_layout,
#endif
#if GL_NV_uniform_buffer_unified_memory
  __GLEW_NV_uniform_buffer_unified_memory,
#endif
#if GL_NV_vdpau_interop
  __GLEW_NV_vdpau_interop,
#endif
#if GL_NV_vdpau_interop2
  __GLEW_NV_vdpau_interop2,
#endif
#if GL_NV_vertex_array_range
  __GLEW_NV_vertex_array_range,
#endif
#if GL_NV_vertex_array_range2
  __GLEW_NV_vertex_array_range2,
#endif
#if GL_NV_vertex_attrib_integer_64bit
  __GLEW_NV_vertex_attrib_integer_64bit,
#endif
#if GL_NV_vertex_buffer_unified_memory
  __GLEW_NV_vertex_buffer_unified_memory,
#endif
#if GL_NV_vertex_program
  __GLEW_NV_vertex_program,
#endif
#if GL_NV_vertex_program1_1
  __GLEW_NV_vertex_program1_1,
#endif
#if GL_NV_vertex_program2
  __GLEW_NV_vertex_program2,
#endif
#if GL_NV_vertex_program2_option
  __GLEW_NV_vertex_program2_option,
#endif
#if GL_NV_vertex_program3
  __GLEW_NV_vertex_program3,
#endif
#if GL_NV_vertex_program4
  __GLEW_NV_vertex_program4,
#endif
#if GL_NV_video_capture
  __GLEW_NV_video_capture,
#endif
#if GL_NV_viewport_array
  __GLEW_NV_viewport_array,
#endif
#if GL_NV_viewport_array2
  __GLEW_NV_viewport_array2,
#endif
#if GL_NV_viewport_swizzle
  __GLEW_NV_viewport_swizzle,
#endif
#if GL_OES_EGL_image
  __GLEW_OES_EGL_image,
#endif
#if GL_OES_EGL_image_external
  __GLEW_OES_EGL_image_external,
#endif
#if GL_OES_EGL_image_external_essl3
  __GLEW_OES_EGL_image_external_essl3,
#endif
#if GL_OES_blend_equation_separate
  __GLEW_OES_blend_equation_separate,
#endif
#if GL_OES_blend_func_separate
  __GLEW_OES_blend_func_separate,
#endif
#if GL_OES_blend_subtract
  __GLEW_OES_blend_subtract,
#endif
#if GL_OES_byte_coordinates
  __GLEW_OES_byte_coordinates,
#endif
#if GL_OES_compressed_ETC1_RGB8_texture
  __GLEW_OES_compressed_ETC1_RGB8_texture,
#endif
#if GL_OES_compressed_paletted_texture
  __GLEW_OES_compressed_paletted_texture,
#endif
#if GL_OES_copy_image
  __GLEW_OES_copy_image,
#endif
#if GL_OES_depth24
  __GLEW_OES_depth24,
#endif
#if GL_OES_depth32
  __GLEW_OES_depth32,
#endif
#if GL_OES_depth_texture
  __GLEW_OES_depth_texture,
#endif
#if GL_OES_depth_texture_cube_map
  __GLEW_OES_depth_texture_cube_map,
#endif
#if GL_OES_draw_buffers_indexed
  __GLEW_OES_draw_buffers_indexed,
#endif
#if GL_OES_draw_texture
  __GLEW_OES_draw_texture,
#endif
#if GL_OES_element_index_uint
  __GLEW_OES_element_index_uint,
#endif
#if GL_OES_extended_matrix_palette
  __GLEW_OES_extended_matrix_palette,
#endif
#if GL_OES_fbo_render_mipmap
  __GLEW_OES_fbo_render_mipmap,
#endif
#if GL_OES_fragment_precision_high
  __GLEW_OES_fragment_precision_high,
#endif
#if GL_OES_framebuffer_object
  __GLEW_OES_framebuffer_object,
#endif
#if GL_OES_geometry_point_size
  __GLEW_OES_geometry_point_size,
#endif
#if GL_OES_geometry_shader
  __GLEW_OES_geometry_shader,
#endif
#if GL_OES_get_program_binary
  __GLEW_OES_get_program_binary,
#endif
#if GL_OES_gpu_shader5
  __GLEW_OES_gpu_shader5,
#endif
#if GL_OES_mapbuffer
  __GLEW_OES_mapbuffer,
#endif
#if GL_OES_matrix_get
  __GLEW_OES_matrix_get,
#endif
#if GL_OES_matrix_palette
  __GLEW_OES_matrix_palette,
#endif
#if GL_OES_packed_depth_stencil
  __GLEW_OES_packed_depth_stencil,
#endif
#if GL_OES_point_size_array
  __GLEW_OES_point_size_array,
#endif
#if GL_OES_point_sprite
  __GLEW_OES_point_sprite,
#endif
#if GL_OES_read_format
  __GLEW_OES_read_format,
#endif
#if GL_OES_required_internalformat
  __GLEW_OES_required_internalformat,
#endif
#if GL_OES_rgb8_rgba8
  __GLEW_OES_rgb8_rgba8,
#endif
#if GL_OES_sample_shading
  __GLEW_OES_sample_shading,
#endif
#if GL_OES_sample_variables
  __GLEW_OES_sample_variables,
#endif
#if GL_OES_shader_image_atomic
  __GLEW_OES_shader_image_atomic,
#endif
#if GL_OES_shader_io_blocks
  __GLEW_OES_shader_io_blocks,
#endif
#if GL_OES_shader_multisample_interpolation
  __GLEW_OES_shader_multisample_interpolation,
#endif
#if GL_OES_single_precision
  __GLEW_OES_single_precision,
#endif
#if GL_OES_standard_derivatives
  __GLEW_OES_standard_derivatives,
#endif
#if GL_OES_stencil1
  __GLEW_OES_stencil1,
#endif
#if GL_OES_stencil4
  __GLEW_OES_stencil4,
#endif
#if GL_OES_stencil8
  __GLEW_OES_stencil8,
#endif
#if GL_OES_surfaceless_context
  __GLEW_OES_surfaceless_context,
#endif
#if GL_OES_tessellation_point_size
  __GLEW_OES_tessellation_point_size,
#endif
#if GL_OES_tessellation_shader
  __GLEW_OES_tessellation_shader,
#endif
#if GL_OES_texture_3D
  __GLEW_OES_texture_3D,
#endif
#if GL_OES_texture_border_clamp
  __GLEW_OES_texture_border_clamp,
#endif
#if GL_OES_texture_buffer
  __GLEW_OES_texture_buffer,
#endif
#if GL_OES_texture_compression_astc
  __GLEW_OES_texture_compression_astc,
#endif
#if GL_OES_texture_cube_map
  __GLEW_OES_texture_cube_map,
#endif
#if GL_OES_texture_cube_map_array
  __GLEW_OES_texture_cube_map_array,
#endif
#if GL_OES_texture_env_crossbar
  __GLEW_OES_texture_env_crossbar,
#endif
#if GL_OES_texture_mirrored_repeat
  __GLEW_OES_texture_mirrored_repeat,
#endif
#if GL_OES_texture_npot
  __GLEW_OES_texture_npot,
#endif
#if GL_OES_texture_stencil8
  __GLEW_OES_texture_stencil8,
#endif
#if GL_OES_texture_storage_multisample_2d_array
  __GLEW_OES_texture_storage_multisample_2d_array,
#endif
#if GL_OES_texture_view
  __GLEW_OES_texture_view,
#endif
#if GL_OES_vertex_array_object
  __GLEW_OES_vertex_array_object,
#endif
#if GL_OES_vertex_half_float
  __GLEW_OES_vertex_half_float,
#endif
#if GL_OES_vertex_type_10_10_10_2
  __GLEW_OES_vertex_type_10_10_10_2,
#endif
#if GL_OML_interlace
  __GLEW_OML_interlace,
#endif
#if GL_OML_resample
  __GLEW_OML_resample,
#endif
#if GL_OML_subsample
  __GLEW_OML_subsample,
#endif
#if GL_OVR_multiview
  __GLEW_OVR_multiview,
#endif
#if GL_OVR_multiview2
  __GLEW_OVR_multiview2,
#endif
#if GL_OVR_multiview_multisampled_render_to_texture
  __GLEW_OVR_multiview_multisampled_render_to_texture,
#endif
#if GL_PGI_misc_hints
  __GLEW_PGI_misc_hints,
#endif
#if GL_PGI_vertex_hints
  __GLEW_PGI_vertex_hints,
#endif
#if GL_QCOM_YUV_texture_gather
  __GLEW_QCOM_YUV_texture_gather,
#endif
#if GL_QCOM_alpha_test
  __GLEW_QCOM_alpha_test,
#endif
#if GL_QCOM_binning_control
  __GLEW_QCOM_binning_control,
#endif
#if GL_QCOM_driver_control
  __GLEW_QCOM_driver_control,
#endif
#if GL_QCOM_extended_get
  __GLEW_QCOM_extended_get,
#endif
#if GL_QCOM_extended_get2
  __GLEW_QCOM_extended_get2,
#endif
#if GL_QCOM_frame_extrapolation
  __GLEW_QCOM_frame_extrapolation,
#endif
#if GL_QCOM_framebuffer_foveated
  __GLEW_QCOM_framebuffer_foveated,
#endif
#if GL_QCOM_motion_estimation
  __GLEW_QCOM_motion_estimation,
#endif
#if GL_QCOM_perfmon_global_mode
  __GLEW_QCOM_perfmon_global_mode,
#endif
#if GL_QCOM_render_sRGB_R8_RG8
  __GLEW_QCOM_render_sRGB_R8_RG8,
#endif
#if GL_QCOM_render_shared_exponent
  __GLEW_QCOM_render_shared_exponent,
#endif
#if GL_QCOM_shader_framebuffer_fetch_noncoherent
  __GLEW_QCOM_shader_framebuffer_fetch_noncoherent,
#endif
#if GL_QCOM_shader_framebuffer_fetch_rate
  __GLEW_QCOM_shader_framebuffer_fetch_rate,
#endif
#if GL_QCOM_shading_rate
  __GLEW_QCOM_shading_rate,
#endif
#if GL_QCOM_texture_foveated
  __GLEW_QCOM_texture_foveated,
#endif
#if GL_QCOM_texture_foveated2
  __GLEW_QCOM_texture_foveated2,
#endif
#if GL_QCOM_texture_foveated_subsampled_layout
  __GLEW_QCOM_texture_foveated_subsampled_layout,
#endif
#if GL_QCOM_texture_lod_bias
  __GLEW_QCOM_texture_lod_bias,
#endif
#if GL_QCOM_tiled_rendering
  __GLEW_QCOM_tiled_rendering,
#endif
#if GL_QCOM_writeonly_rendering
  __GLEW_QCOM_writeonly_rendering,
#endif
#if GL_QCOM_ycbcr_degamma
  __GLEW_QCOM_ycbcr_degamma,
#endif
#if GL_REGAL_ES1_0_compatibility
  __GLEW_REGAL_ES1_0_compatibility,
#endif
#if GL_REGAL_ES1_1_compatibility
  __GLEW_REGAL_ES1_1_compatibility,
#endif
#if GL_REGAL_enable
  __GLEW_REGAL_enable,
#endif
#if GL_REGAL_error_string
  __GLEW_REGAL_error_string,
#endif
#if GL_REGAL_extension_query
  __GLEW_REGAL_extension_query,
#endif
#if GL_REGAL_log
  __GLEW_REGAL_log,
#endif
#if GL_REGAL_proc_address
  __GLEW_REGAL_proc_address,
#endif
#if GL_REND_screen_coordinates
  __GLEW_REND_screen_coordinates,
#endif
#if GL_S3_s3tc
  __GLEW_S3_s3tc,
#endif
#if GL_SGIS_clip_band_hint
  __GLEW_SGIS_clip_band_hint,
#endif
#if GL_SGIS_color_range
  __GLEW_SGIS_color_range,
#endif
#if GL_SGIS_detail_texture
  __GLEW_SGIS_detail_texture,
#endif
#if GL_SGIS_fog_function
  __GLEW_SGIS_fog_function,
#endif
#if GL_SGIS_generate_mipmap
  __GLEW_SGIS_generate_mipmap,
#endif
#if GL_SGIS_line_texgen
  __GLEW_SGIS_line_texgen,
#endif
#if GL_SGIS_multisample
  __GLEW_SGIS_multisample,
#endif
#if GL_SGIS_multitexture
  __GLEW_SGIS_multitexture,
#endif
#if GL_SGIS_pixel_texture
  __GLEW_SGIS_pixel_texture,
#endif
#if GL_SGIS_point_line_texgen
  __GLEW_SGIS_point_line_texgen,
#endif
#if GL_SGIS_shared_multisample
  __GLEW_SGIS_shared_multisample,
#endif
#if GL_SGIS_sharpen_texture
  __GLEW_SGIS_sharpen_texture,
#endif
#if GL_SGIS_texture4D
  __GLEW_SGIS_texture4D,
#endif
#if GL_SGIS_texture_border_clamp
  __GLEW_SGIS_texture_border_clamp,
#endif
#if GL_SGIS_texture_edge_clamp
  __GLEW_SGIS_texture_edge_clamp,
#endif
#if GL_SGIS_texture_filter4
  __GLEW_SGIS_texture_filter4,
#endif
#if GL_SGIS_texture_lod
  __GLEW_SGIS_texture_lod,
#endif
#if GL_SGIS_texture_select
  __GLEW_SGIS_texture_select,
#endif
#if GL_SGIX_async
  __GLEW_SGIX_async,
#endif
#if GL_SGIX_async_histogram
  __GLEW_SGIX_async_histogram,
#endif
#if GL_SGIX_async_pixel
  __GLEW_SGIX_async_pixel,
#endif
#if GL_SGIX_bali_g_instruments
  __GLEW_SGIX_bali_g_instruments,
#endif
#if GL_SGIX_bali_r_instruments
  __GLEW_SGIX_bali_r_instruments,
#endif
#if GL_SGIX_bali_timer_instruments
  __GLEW_SGIX_bali_timer_instruments,
#endif
#if GL_SGIX_blend_alpha_minmax
  __GLEW_SGIX_blend_alpha_minmax,
#endif
#if GL_SGIX_blend_cadd
  __GLEW_SGIX_blend_cadd,
#endif
#if GL_SGIX_blend_cmultiply
  __GLEW_SGIX_blend_cmultiply,
#endif
#if GL_SGIX_calligraphic_fragment
  __GLEW_SGIX_calligraphic_fragment,
#endif
#if GL_SGIX_clipmap
  __GLEW_SGIX_clipmap,
#endif
#if GL_SGIX_color_matrix_accuracy
  __GLEW_SGIX_color_matrix_accuracy,
#endif
#if GL_SGIX_color_table_index_mode
  __GLEW_SGIX_color_table_index_mode,
#endif
#if GL_SGIX_complex_polar
  __GLEW_SGIX_complex_polar,
#endif
#if GL_SGIX_convolution_accuracy
  __GLEW_SGIX_convolution_accuracy,
#endif
#if GL_SGIX_cube_map
  __GLEW_SGIX_cube_map,
#endif
#if GL_SGIX_cylinder_texgen
  __GLEW_SGIX_cylinder_texgen,
#endif
#if GL_SGIX_datapipe
  __GLEW_SGIX_datapipe,
#endif
#if GL_SGIX_decimation
  __GLEW_SGIX_decimation,
#endif
#if GL_SGIX_depth_pass_instrument
  __GLEW_SGIX_depth_pass_instrument,
#endif
#if GL_SGIX_depth_texture
  __GLEW_SGIX_depth_texture,
#endif
#if GL_SGIX_dvc
  __GLEW_SGIX_dvc,
#endif
#if GL_SGIX_flush_raster
  __GLEW_SGIX_flush_raster,
#endif
#if GL_SGIX_fog_blend
  __GLEW_SGIX_fog_blend,
#endif
#if GL_SGIX_fog_factor_to_alpha
  __GLEW_SGIX_fog_factor_to_alpha,
#endif
#if GL_SGIX_fog_layers
  __GLEW_SGIX_fog_layers,
#endif
#if GL_SGIX_fog_offset
  __GLEW_SGIX_fog_offset,
#endif
#if GL_SGIX_fog_patchy
  __GLEW_SGIX_fog_patchy,
#endif
#if GL_SGIX_fog_scale
  __GLEW_SGIX_fog_scale,
#endif
#if GL_SGIX_fog_texture
  __GLEW_SGIX_fog_texture,
#endif
#if GL_SGIX_fragment_lighting_space
  __GLEW_SGIX_fragment_lighting_space,
#endif
#if GL_SGIX_fragment_specular_lighting
  __GLEW_SGIX_fragment_specular_lighting,
#endif
#if GL_SGIX_fragments_instrument
  __GLEW_SGIX_fragments_instrument,
#endif
#if GL_SGIX_framezoom
  __GLEW_SGIX_framezoom,
#endif
#if GL_SGIX_icc_texture
  __GLEW_SGIX_icc_texture,
#endif
#if GL_SGIX_igloo_interface
  __GLEW_SGIX_igloo_interface,
#endif
#if GL_SGIX_image_compression
  __GLEW_SGIX_image_compression,
#endif
#if GL_SGIX_impact_pixel_texture
  __GLEW_SGIX_impact_pixel_texture,
#endif
#if GL_SGIX_instrument_error
  __GLEW_SGIX_instrument_error,
#endif
#if GL_SGIX_interlace
  __GLEW_SGIX_interlace,
#endif
#if GL_SGIX_ir_instrument1
  __GLEW_SGIX_ir_instrument1,
#endif
#if GL_SGIX_line_quality_hint
  __GLEW_SGIX_line_quality_hint,
#endif
#if GL_SGIX_list_priority
  __GLEW_SGIX_list_priority,
#endif
#if GL_SGIX_mpeg1
  __GLEW_SGIX_mpeg1,
#endif
#if GL_SGIX_mpeg2
  __GLEW_SGIX_mpeg2,
#endif
#if GL_SGIX_nonlinear_lighting_pervertex
  __GLEW_SGIX_nonlinear_lighting_pervertex,
#endif
#if GL_SGIX_nurbs_eval
  __GLEW_SGIX_nurbs_eval,
#endif
#if GL_SGIX_occlusion_instrument
  __GLEW_SGIX_occlusion_instrument,
#endif
#if GL_SGIX_packed_6bytes
  __GLEW_SGIX_packed_6bytes,
#endif
#if GL_SGIX_pixel_texture
  __GLEW_SGIX_pixel_texture,
#endif
#if GL_SGIX_pixel_texture_bits
  __GLEW_SGIX_pixel_texture_bits,
#endif
#if GL_SGIX_pixel_texture_lod
  __GLEW_SGIX_pixel_texture_lod,
#endif
#if GL_SGIX_pixel_tiles
  __GLEW_SGIX_pixel_tiles,
#endif
#if GL_SGIX_polynomial_ffd
  __GLEW_SGIX_polynomial_ffd,
#endif
#if GL_SGIX_quad_mesh
  __GLEW_SGIX_quad_mesh,
#endif
#if GL_SGIX_reference_plane
  __GLEW_SGIX_reference_plane,
#endif
#if GL_SGIX_resample
  __GLEW_SGIX_resample,
#endif
#if GL_SGIX_scalebias_hint
  __GLEW_SGIX_scalebias_hint,
#endif
#if GL_SGIX_shadow
  __GLEW_SGIX_shadow,
#endif
#if GL_SGIX_shadow_ambient
  __GLEW_SGIX_shadow_ambient,
#endif
#if GL_SGIX_slim
  __GLEW_SGIX_slim,
#endif
#if GL_SGIX_spotlight_cutoff
  __GLEW_SGIX_spotlight_cutoff,
#endif
#if GL_SGIX_sprite
  __GLEW_SGIX_sprite,
#endif
#if GL_SGIX_subdiv_patch
  __GLEW_SGIX_subdiv_patch,
#endif
#if GL_SGIX_subsample
  __GLEW_SGIX_subsample,
#endif
#if GL_SGIX_tag_sample_buffer
  __GLEW_SGIX_tag_sample_buffer,
#endif
#if GL_SGIX_texture_add_env
  __GLEW_SGIX_texture_add_env,
#endif
#if GL_SGIX_texture_coordinate_clamp
  __GLEW_SGIX_texture_coordinate_clamp,
#endif
#if GL_SGIX_texture_lod_bias
  __GLEW_SGIX_texture_lod_bias,
#endif
#if GL_SGIX_texture_mipmap_anisotropic
  __GLEW_SGIX_texture_mipmap_anisotropic,
#endif
#if GL_SGIX_texture_multi_buffer
  __GLEW_SGIX_texture_multi_buffer,
#endif
#if GL_SGIX_texture_phase
  __GLEW_SGIX_texture_phase,
#endif
#if GL_SGIX_texture_range
  __GLEW_SGIX_texture_range,
#endif
#if GL_SGIX_texture_scale_bias
  __GLEW_SGIX_texture_scale_bias,
#endif
#if GL_SGIX_texture_supersample
  __GLEW_SGIX_texture_supersample,
#endif
#if GL_SGIX_vector_ops
  __GLEW_SGIX_vector_ops,
#endif
#if GL_SGIX_vertex_array_object
  __GLEW_SGIX_vertex_array_object,
#endif
#if GL_SGIX_vertex_preclip
  __GLEW_SGIX_vertex_preclip,
#endif
#if GL_SGIX_vertex_preclip_hint
  __GLEW_SGIX_vertex_preclip_hint,
#endif
#if GL_SGIX_ycrcb
  __GLEW_SGIX_ycrcb,
#endif
#if GL_SGIX_ycrcb_subsample
  __GLEW_SGIX_ycrcb_subsample,
#endif
#if GL_SGIX_ycrcba
  __GLEW_SGIX_ycrcba,
#endif
#if GL_SGI_color_matrix
  __GLEW_SGI_color_matrix,
#endif
#if GL_SGI_color_table
  __GLEW_SGI_color_table,
#endif
#if GL_SGI_complex
  __GLEW_SGI_complex,
#endif
#if GL_SGI_complex_type
  __GLEW_SGI_complex_type,
#endif
#if GL_SGI_fft
  __GLEW_SGI_fft,
#endif
#if GL_SGI_texture_color_table
  __GLEW_SGI_texture_color_table,
#endif
#if GL_SUNX_constant_data
  __GLEW_SUNX_constant_data,
#endif
#if GL_SUN_convolution_border_modes
  __GLEW_SUN_convolution_border_modes,
#endif
#if GL_SUN_global_alpha
  __GLEW_SUN_global_alpha,
#endif
#if GL_SUN_mesh_array
  __GLEW_SUN_mesh_array,
#endif
#if GL_SUN_read_video_pixels
  __GLEW_SUN_read_video_pixels,
#endif
#if GL_SUN_slice_accum
  __GLEW_SUN_slice_accum,
#endif
#if GL_SUN_triangle_list
  __GLEW_SUN_triangle_list,
#endif
#if GL_SUN_vertex
  __GLEW_SUN_vertex,
#endif
#if GL_VERSION_1_2
  __GLEW_VERSION_1_2,
#endif
#if GL_VERSION_1_2_1
  __GLEW_VERSION_1_2_1,
#endif
#if GL_VERSION_1_3
  __GLEW_VERSION_1_3,
#endif
#if GL_VERSION_1_4
  __GLEW_VERSION_1_4,
#endif
#if GL_VERSION_1_5
  __GLEW_VERSION_1_5,
#endif
#if GL_VERSION_2_0
  __GLEW_VERSION_2_0,
#endif
#if GL_VERSION_2_1
  __GLEW_VERSION_2_1,
#endif
#if GL_VERSION_3_0
  __GLEW_VERSION_3_0,
#endif
#if GL_VERSION_3_1
  __GLEW_VERSION_3_1,
#endif
#if GL_VERSION_3_2
  __GLEW_VERSION_3_2,
#endif
#if GL_VERSION_3_3
  __GLEW_VERSION_3_3,
#endif
#if GL_VERSION_4_0
  __GLEW_VERSION_4_0,
#endif
#if GL_VERSION_4_1
  __GLEW_VERSION_4_1,
#endif
#if GL_VERSION_4_2
  __GLEW_VERSION_4_2,
#endif
#if GL_VERSION_4_3
  __GLEW_VERSION_4_3,
#endif
#if GL_VERSION_4_4
  __GLEW_VERSION_4_4,
#endif
#if GL_VERSION_4_5
  __GLEW_VERSION_4_5,
#endif
#if GL_VERSION_4_6
  __GLEW_VERSION_4_6,
#endif
#if GL_VIV_shader_binary
  __GLEW_VIV_shader_binary,
#endif
#if GL_WIN_phong_shading
  __GLEW_WIN_phong_shading,
#endif
#if GL_WIN_scene_markerXXX
  __GLEW_WIN_scene_markerXXX,
#endif
#if GL_WIN_specular_fog
  __GLEW_WIN_specular_fog,
#endif
#if GL_WIN_swap_hint
  __GLEW_WIN_swap_hint
#endif
};
    }
}
